#pragma once
#include "MyString.h"
class Text
{
public:
	int length;
	vector<MyString> text;
	void AddStr(MyString strToAdd);
	void ClearText();
	void ToUpper();
	void FindARow();
	void DeleteRow(int amount);
	MyString& operator [](int index);
	void Print(int i);
	void Print();
}; 
