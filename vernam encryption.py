import os

def binNums(n):
		return 128 * ((1/2) ** n)

def XOR(a, b):
	if (a == "1" and b == "0") or (a == "0" and b == "1"):
		return "1"
	else:
		return "0"

def getBinaryText(text, ASCII_Denery):
	binaryASCII_Text = [["" for x in range(8)] for x in range(len(text))]
	for i in range(len(binaryASCII_Text)):
		value = ASCII_Denery[i]
		for x in range(8):
			binNumber = binNums(x)
			if value - binNumber >= 0:
				binaryASCII_Text[i][x] = "1"
				value -= binNumber
			else:
				binaryASCII_Text[i][x] = "0"

	return binaryASCII_Text
def clearConsole():
	# for windows
    if os.name == 'nt':
        _ = os.system('cls')
  
    # for mac and linux(here, os.name is 'posix')
    else:
        _ = os.system('clear')

binToHex = {
	"0000": "0",
	"0001": "1",
	"0010": "2",
	"0011": "3",
	"0100": "4",
	"0101": "5",
	"0110": "6",
	"0111": "7",
	"1000": "8",
	"1001": "9",
	"1010": "A",
	"1011": "B",
	"1100": "C",
	"1101": "D",
	"1110": "E",
	"1111": "F" 
}

hexToBin = {value : key for key, value in binToHex.items()}


	
while True:
	clearConsole()

	choice = input("Do you wish to 'encrypt' or 'decrypt'? (type 'stop' to exit the program) ").lower()
	if choice == "encrypt":
		plaintext = input("Plaintext you want to encrypt: ")
		key = input("Key to encrypt with (make sure its the same length as the plain text): ")

		while len(key) != len(plaintext):
			print("Try Again - Key didn't match the plaintext length")
			key = input("Key to encrypt with (make sure its the same length as the plain text): ")

		binaryASCII_plaintext = []
		binaryASCII_key = []

		ASCIIcodes_plaintext = []
		ASCIIcodes_key = []

		for letterPlain, letterKey in zip(plaintext, key):
			ASCIIcodes_plaintext.append(ord(letterPlain))
			ASCIIcodes_key.append(ord(letterKey))

		binaryASCII_plaintext = getBinaryText(plaintext, ASCIIcodes_plaintext)
		binaryASCII_key = getBinaryText(key, ASCIIcodes_key)


		binaryASCII_Encrypted = [["" for x in range(8)] for x in range(len(plaintext))]

		for i in range(len(plaintext)):
			for x in range(8):
				a = binaryASCII_plaintext[i][x]
				b = binaryASCII_key[i][x]
				xorResult = XOR(a, b)

				binaryASCII_Encrypted[i][x] = xorResult

		

		print("Encrypted text:", end="")

		for letter in binaryASCII_Encrypted:
			nibble1 = "".join(letter[0:4])
			nibble2 = "".join(letter[4:])

			hexBit = binToHex[nibble1] + binToHex[nibble2]
			print(" " + hexBit, end="")

		print("\n")

		input("Press enter to continue")

	elif choice == "decrypt":
		encrypted = input("Input the encrypted text (separate with spaces): ")
		key = input("Input the key used to encrypt (Equal length required): ")
		encryptedHex = encrypted.split(" ")
		while len(key) != len(encryptedHex):
			print("Key was invalid length")
			key = input("Input the key used to encrypt (Equal length required): ")

		length = len(key)

		binaryASCII_encrypted = [["" for x in range(8)] for x in range(length)]

		denaryASCII_key = []

		for letter in key:
			denaryASCII_key.append(ord(letter))

		binaryASCII_key = getBinaryText(key, denaryASCII_key)

		binaryASCII_plaintext = [["" for x in range(8)] for x in range(length)]

		for binaryDigitIndex, hexVal in zip(range(length), encryptedHex):
			for hexDigitIndex in range(2):
				binaryNibble = hexToBin[hexVal[hexDigitIndex]]
				for i in range(4):
					binaryASCII_encrypted[binaryDigitIndex][i+4 if hexDigitIndex == 1 else i] = binaryNibble[i]

		for i in range(len(binaryASCII_encrypted)):
			for x in range(8):
				a = binaryASCII_encrypted[i][x]
				b = binaryASCII_key[i][x]
				xorResult = XOR(a, b)

				binaryASCII_plaintext[i][x] = xorResult
		binaryASCII_plaintexConcatenated = []

		for binary in binaryASCII_plaintext:
			binaryASCII_plaintexConcatenated.append("".join(binary))

		denaryASCII_plaintext = []
		for binary in binaryASCII_plaintexConcatenated:
			denaryASCII_plaintext.append(int(binary, 2))

		plaintextList = []
		for ASCII in denaryASCII_plaintext:
			plaintextList.append(chr(ASCII))

		text = "".join(plaintextList)
		print("Decrypted text: " + text)

		input("Press enter to continue")
	elif choice == "stop":
		quit()
	else:
		print("INVALID CHOICE")

		input("Press enter to continue")
