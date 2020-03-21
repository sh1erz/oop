#pragma once
#include <vector>
#include <iostream>
using namespace std;
class MyString
{
public:
	MyString();
	MyString(char* str);
	char& operator [](int index);
	void Print();
	char* MyStr;
	int length;
};
