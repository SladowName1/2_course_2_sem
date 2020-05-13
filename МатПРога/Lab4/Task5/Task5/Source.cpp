#include <iostream>
#include "LCS.h"
#include "LCH.h"
#include <ctime>
int main2();
int main(int argc, char* argv[])
{
    setlocale(LC_ALL, "rus");
    char X[] = "ALBDACD", Y[] = "CDLDCA";
    clock_t t1 = 0, t2;
    std::cout << std::endl << "-- вычисление длины LCS для X и Y(рекурсия)";
    std::cout << std::endl << "-- последовательность X: " << X;
    std::cout << std::endl << "-- последовательность Y: " << Y;
    t1 = clock();
    int s = lcs(
        sizeof(X) - 1,  // длина   последовательности  X   
        "ALBDACD",       // последовательность X
        sizeof(Y) - 1,  // длина   последовательности  Y
        "CDLDCA"       // последовательность Y
    );
    t2 = clock();
    std::cout << std::endl << "-- длина LCS: " << s << std::endl;
    std::cout << "Time " << t2 - t1 << std::endl;
    main2();
    system("pause");
    return 0;
}
int main2() {

    char z[100] = "";
    char x[] = "ALBDACD",
        y[] = "CDLDCA";
    clock_t t3 = 0, t4;
    t3 = clock();
    int l = lcsd(x, y, z);
    t4 = clock();
    std::cout << std::endl
        << "-- наибольшая общая подпоследовательость - LCS(динамическое"
        << "программирование)" << std::endl;
    std::cout << std::endl << "последовательость X: " << x;
    std::cout << std::endl << "последовательость Y: " << y;
    std::cout << std::endl << "                LCS: " << z;
    std::cout << std::endl << "          длина LCS: " << l;
    std::cout << std::endl << "Time :" << t4 - t3;

    system("pause");
    return 0;

}
