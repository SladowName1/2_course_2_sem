// 4lab_5.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include "LCS.h"
#include <iostream>
#include <ctime>
#include <string>

#define N 15
#define M 15

int main()
{
	setlocale(0, "");
	srand(time(NULL));
	clock_t t1 = 0;
	LCS::Start(LCS::Initialized(M, N), t1);
	return 0;
    return 0;
}

