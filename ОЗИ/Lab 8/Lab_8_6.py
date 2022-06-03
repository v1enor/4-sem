number  = 1998    #Число, которое ввозводим в степень
divider = 19      #Число, на которое делим с остатком
degree  = 2002    #Степень, на которую возводим число

for i_degree in range(1, degree + 1):

    # i_degree - степень возведения числа из диапазона от 1 до degree
    # Возводим число в степень
    in_degree = number ** i_degree
    #Вычисляем остаток от деления
    remaind =  in_degree % divider
    #Выводим результат
    print(str(number) + '^' + str(i_degree) + ' делется на число ' + str(divider) + ' с остатком ' +  str(remaind))    

input('Press key to продолжить ...)') 

