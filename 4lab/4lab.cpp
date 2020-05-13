// 4lab.cpp: определяет точку входа для консольного приложения.
//
//

#include "stdafx.h"
//#include <algorithm>
#include <iostream>
#include <ctime>
//#include <iomanip>
//#include "Levenshtein.h"
//#include "LCS.h"

using namespace std;

char * Gen(int size)
{
	char *str = (char*)malloc(sizeof(char)*size);

	for (int i = 0; i < size; i++) str[i] = rand() % 26 + 'a';
	return str;
}


int main()
{
	setlocale(LC_ALL, "RUS");


	cout << "___________________________Генерируем строки S1, S2_____________________________" << endl << endl;
	char *S1 = Gen(300);
	char *S2 = Gen(250);
	cout << "Строка S1: " << endl;
	for (int i = 0; i < 300; i++) cout << S1[i] << " ";
	cout << endl << endl;
	cout << "Строка S2: " << endl;
	for (int i = 0; i < 250; i++) cout << S2[i] << " ";
	cout << endl << endl;

    return 0;
}

