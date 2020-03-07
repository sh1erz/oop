#include "Header.h"

string Compare(int n1, int n2)
{
    int size = sizeof(int) * 8;
    if ((n1 & (1 << size - 1)) != (n2 & (1 << size - 1)))
    {
        bool currentBit1 = n1 & (1 << size - 1);
        bool currentBit2 = n2 & (1 << size - 1);
        return currentBit1 > currentBit2 ? "num 1 < num 2" : "num 1 > num 2";
    }
    for (int i = size - 2; i >= 0; i--)
    {
        bool currentBit1 = n1 & (1 << i);
        bool currentBit2 = n2 & (1 << i);
        if (currentBit1 == currentBit2)
        {
            continue;
        }
        return (currentBit1 < currentBit2)  ?  "num 1 < num 2"  : "num 1 > num 2" ;
    }
    return "num 1 = num 2";
}

void Dim(int num)
{
    int size = sizeof(int) * 8;
    for (int i = 0; i < size; i++)
    {
        num = num xor (1 << i);
        if (not (num & (1 << i))) { break; }
    }
    cout << num;
}