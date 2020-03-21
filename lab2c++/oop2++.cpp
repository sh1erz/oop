#include <iostream>
#include <string>
#include "MyString.h"
#include "MyText.h"

using namespace std;


int main(){
	int strToDel, chars = 0;
	int NumOfStrs = 0;

	Text text;
	string Input;

	cout << "Number of strings: ";
	cin >> NumOfStrs;
	cout << endl;

	cin.ignore(1);
	for (int i = 0; i < NumOfStrs; i++)
	{
		cout << "Enter " << i + 1 << " string: " << endl;
		getline(cin, Input);
		char* array = new char[Input.length()];
		for (int i = 0; i < strlen(array); i++)
		{
			array[i] = Input[i];
		}
		text.AddStr(array);
		Input.clear();
	}

	cout << endl;
	cout << "Entered strings :\n";
	text.Print();
	cout << "\n******************************\n";


	cout << "All letters to upper register:\n ";
	text.ToUpper();
	text.Print();
	cout << "\n******************************\n";

	text.FindARow();
	cout << "\n******************************\n";

	cout << "Input the amount of chars in string: "; 
	cin >> chars;
	text.DeleteRow(chars);
	cout << "Changed texst is:\n";
	text.Print();

	system("pause");
	return 0;
}