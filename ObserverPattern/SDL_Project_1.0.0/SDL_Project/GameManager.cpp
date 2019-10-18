#include "GameManager.h"
#include "Window.h"
#include "Timer.h"
#include "Scene0.h"
#include <iostream>
#include "ArrowKeyObs.h"
#include "KeyDownObs.h"
#include "Subject.h"

GameManager::GameManager() {
	timer = nullptr;
	isRunning = true;
	currentScene = nullptr;
}


/// In this OnCreate() method, fuction, subroutine, whatever the word, 
bool GameManager::OnCreate() {
	const int SCREEN_WIDTH = 780;
	const int SCREEN_HEIGHT = 400;
	ptr = new Window(SCREEN_WIDTH, SCREEN_HEIGHT);
	if (ptr == nullptr) {
		OnDestroy();
		return false;
	}
	if (ptr->OnCreate() == false) {
		OnDestroy();
		return false;
	}

	timer = new Timer();
	if (timer == nullptr) {
		OnDestroy();
		return false;
	}
	arrobs = new ArrowKeyObs();
	if (arrobs == nullptr) {
		OnDestroy();
		return false;
	}

	keyobs = new KeyDownObs();
	if (keyobs == nullptr) {
		OnDestroy();
		return false;
	}
	subject = new Subject("subject1");
	if (subject == nullptr) {
		OnDestroy();
		return false;
	}

	currentScene = new Scene0(ptr->GetSDL_Window());
	if (currentScene == nullptr) {
		OnDestroy();
		return false;
	}

	if (currentScene->OnCreate() == false) {
		OnDestroy();
		return false;
	}

	return true;
}

/// Here's the whole game
void GameManager::Run() {
	timer->Start();
	SDL_Event event;
	//have the observers subscribe to the subject
	arrobs->Subscribe(subject);
	keyobs->Subscribe(subject);
	while (isRunning) {
		timer->UpdateFrameTicks();
		currentScene->Update(timer->GetDeltaTime());
		currentScene->Render();
		//check for an sdl_event
		if (SDL_PollEvent(&event)) {
			//notify all subscribers of the event that happened
			subject->Notify(event);
			//option for the key observer to unsubscribe
			if (event.key.keysym.sym == SDLK_F1) {
				keyobs->UnSubscribe(subject);
			}
			//option for the arrow key observer to unsubscribe
			else if (event.key.keysym.sym == SDLK_F2) {
				arrobs->UnSubscribe(subject);
			}
			
		}

		/// Keeep the event loop running at a proper rate
		SDL_Delay(timer->GetSleepTime(60)); ///60 frames per sec
	}
}

GameManager::~GameManager() {}

void GameManager::OnDestroy(){
	if (ptr) delete ptr;
	if (timer) delete timer;
	if (currentScene) delete currentScene;
	if (arrobs) delete arrobs;
	if (keyobs) delete keyobs;
	if (subject) delete subject;
}