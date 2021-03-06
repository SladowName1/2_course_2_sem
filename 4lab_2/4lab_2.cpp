// 4lab_2.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <algorithm>
#include <iostream>
#include <ctime>
#include <iomanip>
#include "Levenshtein.h"
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





	cout << "_____________________________Дистанция Левенштейна______________________________" << endl << endl;
	int dist = 0;
	clock_t t1 = 0, t2 = 0;

	const char Lom[] = { 'Л', 'о', 'м'};
	const char Gomon[] = { 'Г', 'о', 'м', 'о', 'н' };
	for (int i = 0; i < 3; i++) cout << Lom[i] << " "; cout << endl;
	for (int i = 0; i < 5; i++) cout << Gomon[i] << " "; cout << endl;
	dist = levenshtein_r(4, Lom, 5, Gomon);
	cout << "Дистанция Левенштейна для Лом и Гомон: " << dist << endl << endl;
//	system("pause");


	float k[] = { 0.04, 0.05, 0.0625, 0.1, 0.2, 0.5, 1 };

	for (int i = 0; i < 300 * k[0]; i++) cout << S1[i] << " ";
	cout << endl << endl;
	for (int i = 0; i < 250 * k[0]; i++) cout << S2[i] << " ";
	t1 = clock();
	dist = levenshtein(300 * k[0], S1, 250 * k[0], S2);
	t2 = clock();
	cout << endl << endl;
	cout << "Дистанция Левенштейна с помощью динамического программирования: " << dist << endl;
	cout << "Время вычисления алгоритма: (мс) " << t2 - t1 << endl;
	t1 = clock();
	dist = levenshtein_r(300 * k[0], S1, 250 * k[0], S2);
	t2 = clock();
	cout << "Дистанция Левенштейна с помощью рекурсии: " << dist << endl;
	cout << "Время вычисления алгоритма: (мс) " << t2 - t1 << endl;
//	system("pause");
	cout << endl << endl;

	for (int i = 0; i < 300 * k[1]; i++) cout << S1[i] << " ";
	cout << endl << endl;
	for (int i = 0; i < 250 * k[1]; i++) cout << S2[i] << " ";
	t1 = clock();
	dist = levenshtein(300 * k[1], S1, 250 * k[1], S2);
	t2 = clock();
	cout << endl << endl;
	cout << "Дистанция Левенштейна с помощью динамического программирования: " << dist << endl;
	cout << "Время вычисления алгоритма: (мс) " << t2 - t1 << endl;
	t1 = clock();
	dist = levenshtein_r(300 * k[1], S1, 250 * k[1], S2);
	t2 = clock();
	cout << "Дистанция Левенштейна с помощью рекурсии: " << dist << endl;
	cout << "Время вычисления алгоритма: (мс) " << t2 - t1 << endl;
//	system("pause");
	cout << endl << endl;


	for (int i = 0; i < 300 * k[2]; i++) cout << S1[i] << " ";
	cout << endl << endl;
	for (int i = 0; i < 250 * k[2]; i++) cout << S2[i] << " ";
	t1 = clock();
	dist = levenshtein(300 * k[2], S1, 250 * k[2], S2);
	t2 = clock();
	cout << endl << endl;
	cout << "Дистанция Левенштейна с помощью динамического программирования: " << dist << endl;
	cout << "Время вычисления алгоритма: (мс) " << t2 - t1 << endl;
	t1 = clock();
	dist = levenshtein_r(300 * k[2], S1, 250 * k[2], S2);
	t2 = clock();
	cout << "Дистанция Левенштейна с помощью рекурсии: " << dist << endl;
	cout << "Время вычисления алгоритма: (мс) " << t2 - t1 << endl;
//	system("pause");
	cout << endl << endl;


	for (int i = 0; i < 300 * k[3]; i++) cout << S1[i] << " ";
	cout << endl << endl;
	for (int i = 0; i < 250 * k[3]; i++) cout << S2[i] << " ";
	t1 = clock();
	dist = levenshtein(300 * k[3], S1, 250 * k[3], S2);
	t2 = clock();
	cout << endl << endl;
	cout << "Дистанция Левенштейна с помощью динамического программирования: " << dist << endl;
	cout << "Время вычисления алгоритма: (мс) " << t2 - t1 << endl;
	t1 = clock();
	dist = levenshtein_r(300 * k[3], S1, 250 * k[3], S2);
	t2 = clock();
	cout << "Дистанция Левенштейна с помощью рекурсии: " << dist << endl;
	cout << "Время вычисления алгоритма: (мс) " << t2 - t1 << endl;
	//system("pause");
	cout << endl << endl;

	for (int i = 0; i < 300 * k[4]; i++) cout << S1[i] << " ";
	cout << endl << endl;
	for (int i = 0; i < 250 * k[4]; i++) cout << S2[i] << " ";
	t1 = clock();
	dist = levenshtein(300 * k[4], S1, 250 * k[4], S2);
	t2 = clock();
	cout << endl << endl;
	cout << "Дистанция Левенштейна с помощью динамического программирования: " << dist << endl;
	cout << "Время вычисления алгоритма: (мс) " << t2 - t1 << endl;
	t1 = clock();
	dist = levenshtein_r(300 * k[4], S1, 250 * k[4], S2);
	t2 = clock();
	cout << "Дистанция Левенштейна с помощью рекурсии: " << dist << endl;
	cout << "Время вычисления алгоритма: (мс) " << t2 - t1 << endl;
	//system("pause");
	cout << endl << endl;

	for (int i = 0; i < 300 * k[5]; i++) cout << S1[i] << " ";
	cout << endl << endl;
	for (int i = 0; i < 250 * k[5]; i++) cout << S2[i] << " ";
	t1 = clock();
	dist = levenshtein(300 * k[5], S1, 250 * k[5], S2);
	t2 = clock();
	cout << endl << endl;
	cout << "Дистанция Левенштейна с помощью динамического программирования: " << dist << endl;
	cout << "Время вычисления алгоритма: (мс) " << t2 - t1 << endl;
	t1 = clock();
	dist = levenshtein_r(300 * k[5], S1, 250 * k[5], S2);
	t2 = clock();
	cout << "Дистанция Левенштейна с помощью рекурсии: " << dist << endl;
	cout << "Время вычисления алгоритма: (мс) " << t2 - t1 << endl;
	//system("pause");
	cout << endl << endl;

	for (int i = 0; i < 300 * k[6]; i++) cout << S1[i] << " ";
	cout << endl << endl;
	for (int i = 0; i < 250 * k[6]; i++) cout << S2[i] << " ";
	t1 = clock();
	dist = levenshtein(300 * k[6], S1, 250 * k[6], S2);
	t2 = clock();
	cout << endl << endl;
	cout << "Дистанция Левенштейна с помощью динамического программирования: " << dist << endl;
	cout << "Время вычисления алгоритма: (мс) " << t2 - t1 << endl;
	t1 = clock();
	dist = levenshtein_r(300 * k[6], S1, 250 * k[6], S2);
	t2 = clock();
	cout << "Дистанция Левенштейна с помощью рекурсии: " << dist << endl;
	cout << "Время вычисления алгоритма: (мс)" << t2 - t1 << endl;
	//system("pause");


    return 0;
}

