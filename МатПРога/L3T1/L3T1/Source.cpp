#include <iostream>
#include <string>
#include <time.h>
using namespace std;

void main()
{
	srand(time(NULL));
	string Si="a";
	for (int i = 0;i < 300;i++)
	{
		Si +=rand()%'z'+'a';
	}
	cout << Si;
}