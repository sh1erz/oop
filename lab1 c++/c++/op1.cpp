#include "Header.h"

int main()
{
    int num0, num1;
    char a;
    cout << "task 1? y/n\n";
    cin >> a;
    if (a == 'y') 
    {
        cout << "Enter the number: ";
        cin >> num0;
        Dim(num0);
    }
    else
    {
        cout << "Enter two numbers:\n";
        cin >> num0;
        cin >> num1;
        cout << Compare(num0, num1);
    }


}