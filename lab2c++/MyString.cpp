#include <iostream>
#include <string>
#include "MyString.h"

using namespace std;


MyString::MyString()
{
	MyStr = new char[0];
	length = 0;
}

MyString::MyString(char* str)
{
	MyStr = str;
	length = strlen(str);
}

//����� ��������� []
char& MyString::operator [](int index)
{
	return MyStr[index];
}

//Printing the string
void MyString::Print()
{
	for (int j = 0; j < length; j++)
	{
		cout << MyStr[j];
	}
	cout << endl;
}
char* MyStr;