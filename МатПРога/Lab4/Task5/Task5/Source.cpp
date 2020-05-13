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
    std::cout << std::endl << "-- ���������� ����� LCS ��� X � Y(��������)";
    std::cout << std::endl << "-- ������������������ X: " << X;
    std::cout << std::endl << "-- ������������������ Y: " << Y;
    t1 = clock();
    int s = lcs(
        sizeof(X) - 1,  // �����   ������������������  X   
        "ALBDACD",       // ������������������ X
        sizeof(Y) - 1,  // �����   ������������������  Y
        "CDLDCA"       // ������������������ Y
    );
    t2 = clock();
    std::cout << std::endl << "-- ����� LCS: " << s << std::endl;
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
        << "-- ���������� ����� �������������������� - LCS(������������"
        << "����������������)" << std::endl;
    std::cout << std::endl << "����������������� X: " << x;
    std::cout << std::endl << "����������������� Y: " << y;
    std::cout << std::endl << "                LCS: " << z;
    std::cout << std::endl << "          ����� LCS: " << l;
    std::cout << std::endl << "Time :" << t4 - t3;

    system("pause");
    return 0;

}
