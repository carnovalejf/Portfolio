#include <iostream>
#include <memory>
#include "GameManager.h"
#include "MMath.h"
///#include <SDL.h>
using namespace MATH;

// start with project properties, configuration properties, c/c++, command line add /std:c++latest

int main(int argc, char* args[]) { /// Standard C-style entry point, you need to use it

	// default c++ pointer
	//GameManager *manager = new GameManager();

	// Visual Studio 2015 version introduced in c++ 14
	auto manager = std::unique_ptr<GameManager>(new GameManager());

	// If your using Visual studio 2017 and c++ 17 you can call a macro to aid in the creation
	//auto manager = std::make_unique(GameManager());

	// Using the global function we created below. We can simulate the make_unique functionality in c++ 17
	//auto manager = make_unique<GameManager>(GameManager());
	bool status = manager->OnCreate();

	if (status == true) {
		manager->Run();
	}
	else if (status == false) {
		std::cerr << "Fatal error occured. Cannot start this program" << std::endl;
	}

	return 0;
}

// This global scope function
template<class T, class U>
std::unique_ptr<T> make_unique(U&& u) {
	return std::unique_ptr<T>(new T(std::forward<U>(u)));
}