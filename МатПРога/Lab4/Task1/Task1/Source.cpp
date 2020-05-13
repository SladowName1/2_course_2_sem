#include <iostream>
#include "ctime"
using namespace std;

void main()
{
	for (int i = 0; i < 250;i++) 
	{
		cout << char('a' + rand() % ('z' - 'a')) << " ";
	}
}