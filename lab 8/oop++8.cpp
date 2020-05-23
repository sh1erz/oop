#include <iostream>
#include <random>
using namespace std;



int* Sum(int arr[5][5], int outarr[5])
{
	for (int i = 0; i < 5; i++)
	{
		int sum = 0;
		for (int j = 0; j < 5; j++)
		{
			sum += arr[i][j];
		}
		outarr[i] = sum;
	}
	return outarr;
}


void Createarr(int arr[5][5])
{
	for (int i = 0; i < 5; i++)
	{
		for (int j = 0; j < 5; j++)
		{
			arr[i][j] = rand() % 100;
			cout << arr[i][j] << " ";
		}
		cout << endl;
	}
	cout << endl;
}



int main()
{
	int arr[5][5];
	int outarr[5];
	Createarr(arr);
	int* (*fcnPtr)(int arr[5][5], int outarr[5]) = Sum;
	(*fcnPtr)(arr, outarr);
	for (int i = 0; i < 5; i++)
	{
		cout << outarr[i] << " ";
	}
	
}
