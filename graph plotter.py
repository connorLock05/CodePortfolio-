import matplotlib.pyplot as plt

x = [x for x in range(-5, 6)]

y = []

for xV in x:
    try:
        y.append((xV ** 3) / 2 - 5)
    except ZeroDivisionError:
        print("Zero Division Error")
        y.append(None)

    
plt.plot(x, y)

plt.show()
