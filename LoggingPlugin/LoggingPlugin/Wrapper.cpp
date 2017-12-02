#include "stdafx.h"
#include "Wrapper.h"
#include <Windows.h>
#include <string>
#include <fstream>
#include <iostream>

char* HelloWorld() 
{
	return "Hello World!";
}

void Log(char *a_Objectname, char *a_Item, char *a_Value)
{
	CreateDirectoryA(a_Objectname, NULL);
	if (GetLastError() == ERROR_PATH_NOT_FOUND)
	{
		std::string l_ErrorMsg = "Error creating directory: ";
		l_ErrorMsg += a_Objectname;
		std::string ErrorFile = "ErrorOutput.txt";
		std::ofstream Out(ErrorFile);
		Out << l_ErrorMsg;
		Out.close();
		return;
	}
	///
	std::string l_Dir(a_Objectname);
	l_Dir += "/";
	l_Dir += a_Item;
	l_Dir += ".txt";

	std::ofstream l_Out;
	l_Out.open(l_Dir, std::ios_base::app);
	l_Out << a_Value << std::endl;
	l_Out.close();

}

const char* LoadFile()
{
	std::string r_text = "";
	std::string text;
	std::fstream textFile;
	textFile.open("Root/Parent.txt");
	while (!textFile.eof())
	{
		getline(textFile, text);
		r_text += text;
		r_text.push_back('\n');
	}
	textFile.close();

	return r_text.c_str();
}
