#include <iostream>
#include <string>
#include <vector>
#include "MyString.h"
#include "MyText.h"
using namespace std;



int length = 0;
vector<MyString> text;

//Adding MyString object in vector
void Text::AddStr(MyString strToAdd)
{
	text.push_back(strToAdd);
	length++;
}


//Clearing Text
void Text::ClearText()
{
	text.erase(text.begin(), text.end());
	length = 0;
}

//Making all letters to upper register
void Text::ToUpper()
{
	for (int i = 0; i < length; i++)
	{
		for (int j = 0; j < text[i].length; j++)
		{
			text[i][j] = toupper(text[i][j]);
		}	
	}
}

//Find similar strings
void Text::FindARow()
{
	cout << "Enter number of the string you want to find:\n";
	int Key;
	int ret = 0;
	cin >> Key;
	for (int i = 0; i < length; i++)
	{
		bool flag = true;
		for (int j = 0; j < text[i].length; j++)
		{
			if (text[Key - 1][j] != text[i][j])
			{
				flag = false;
				break;
			}
		}
		if(flag)
		{
			ret++;
		}
	}	
	cout << "Number of similar rows: " << ret << endl;
}



//Return amount of string with the number of chars
void Text::DeleteRow(int amount)
{
	for (int i = length - 1; i >= 0; i--)
	{
		if (text[i].length == amount)
		{
			text.erase(text.begin() + i);
			length--;
		}
	}
}

//For calling operator "[]"
MyString& Text::operator [](int index)
{
	return text[index];
}

//Printing 'i' element of vector
void Text::Print(int i)
{
	text[i].Print();
}

//Printing whole vector
void Text::Print()
{
	for (int i = 0; i < length; i++)
	{
		Print(i);
	}
}