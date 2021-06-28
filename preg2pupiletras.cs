
#include<iostream>
#include<time.h>
#include<stdlib.h>
#include<conio.h>
#include <Windows.h>
#include <iomanip>

using namespace std;

int i, j;
int posicionx, posiciony;

void ingresadatos(int filas, int columnas, char** matrizCaracteres)
{
	char letras[] = "abcdefghijklmn\xA4opqrstuvwxyz";
	int numdeletras = sizeof(letras) / sizeof(letras[0]) - 1;

	srand(time(0));//numeros Aleatorios en funcion del tiempo

	for (int i = 0; i < filas; i++) {
		for (int j = 0; j < columnas; j++)
		{

			matrizCaracteres[i][j] = letras[rand() % numdeletras];//Agrega numero aleatorio a la posicion ij de la matriz;
		}

	}

	//cout << numdeletras<<endl;
	//cout << sizeof(letras) << endl;
	//cout << strlen(letras);
}


void salidadatos(int filas, int columnas, char** matrizCaracteres)
{


	for (int i = 0; i < filas; i++)
	{
		for (int j = 0; j < columnas; j++)
			cout << matrizCaracteres[i][j] << "\t";

		cout << endl;
	}
}




bool verifacarPalabra(int filas, int columnas, string palabra, char** matrizCaracteres) {
	string aux, vacia;
	int contador = 0;
	
	
	bool loEncontro;


	//a la derecha
	for (i = 0; i < filas; i++)
	{
		for (int k = 0; k <= columnas - palabra.length(); k++)
		{
			for (j = k; j < palabra.length() + k; j++)
			{
				aux += matrizCaracteres[i][j];
			}
			if (palabra == aux)
			{
				contador++;
				posicionx = i ;
				posiciony = j-(palabra.length());
				loEncontro= true;


			}
			aux = vacia;
		}

	}

	//horizontal izquierda
	for (int i = 0; i < filas; i++)
	{
		for (int k = columnas - 1; k >= palabra.length(); k--)
		{
			for (int j = k; j > k - palabra.length(); j--)
			{
				aux += matrizCaracteres[i][j];
			}
			if (palabra == aux)
			{
				contador++;
				posicionx = i ;
				posiciony = j - (palabra.length()-1);
				loEncontro= true;
			}
			aux = vacia;
		}

	}

	//vertical bajando
	for (int i = 0; i < columnas; i++)
	{
		for (int k = 0; k <= filas - palabra.length(); k++)
		{
			for (int j = k; j < palabra.length() + k; j++)
			{
				aux += matrizCaracteres[j][i];
			}
			if (palabra == aux)
			{
				contador++;
				posicionx = j - palabra.length();
				posiciony = i - palabra.length();
				loEncontro= true;
			}
			aux = vacia;
		}

	}

	//vertical subiendo
	for (int i = 0; i < columnas; i++)
	{
		for (int k = filas - 1; k >= filas - palabra.length(); k--)
		{
			for (int j = k; j > k - palabra.length(); j--)
			{
				aux += matrizCaracteres[j][i];
			}
			if (palabra == aux)
			{
				contador++;
				posicionx = j-palabra.length()-1;
				posiciony = i ;
				loEncontro= true;
			}
			aux = vacia;
		}

	}
	if (contador == 0)
	{
		loEncontro= false;
	}

	return loEncontro;

}
void pupiletras(int filas, int columnas, string palabra, char** matrizCaracteres) {
	int acertadas = 0, erradas = 0;
	string salir;
	do
	{
		if (verifacarPalabra(filas, columnas, palabra, matrizCaracteres))
		{
			cout << "palabra encontrada..." << endl;
			acertadas++;
		}
		else
		{
			cout << "la palabra no se encontrada en el pupiletras" << endl;
			erradas++;
		}
		cout << "posicion primer caracter"<<"("<<posicionx<<","<<posiciony<<")"<<endl;
		cout << "Para salir, escriba: salir" << endl;
		cin >> salir;

	} while (salir != "salir");
	cout << "acertadas: " << acertadas << " erradas: " << erradas << endl;
	
}

int main()
{
	int filas, columnas;
	string palabra;
	cout << "ingrese numero filas " << endl;
	cin >> filas;
	cout << "ingrese numero columnas" << endl;
	cin >> columnas;

	char** matrizCaracteres;
	matrizCaracteres = new char* [filas];
	for (int i = 0; i < filas; i++)
		matrizCaracteres[i] = new char[columnas];
	ingresadatos(filas, columnas, matrizCaracteres);
	salidadatos(filas, columnas, matrizCaracteres);

	do
	{
		cout << "ingrese la palabra a buscar, mayor de 3 caracteres" << endl;
		cin >> palabra;
	} while (palabra.length() < 3);
	pupiletras(filas, columnas, palabra, matrizCaracteres);


	for (int i = 0; i < filas; i++)
		delete[] matrizCaracteres[i];
	delete[] matrizCaracteres;

	return 0;
}