base = int(input("Base: "))
values = int(input("Number: "))

output = []

current = 0
while current < values:
    output.append(base ** current)
    current += 1

print(output)

total = 0
for num in output:
    total += num

print("Total:", total)
