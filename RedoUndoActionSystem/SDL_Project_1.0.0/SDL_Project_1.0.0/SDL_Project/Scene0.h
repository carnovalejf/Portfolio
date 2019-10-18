#ifndef SCENE0_H
#define SCENE0_H

#include "MMath.h"
#include "Scene.h"
#include "Actor.h"
#include <SDL.h>

using namespace MATH;
class Scene0 : public Scene {
private:
	SDL_Window *window;
	Matrix4 projectionMatrix;
	SDL_Surface *jetSkiImage;
	Vec3 jetSkiPos;
	SDL_Rect jetSkiRect;
	std::shared_ptr<Actor> actor;
public:
	
	Scene0(SDL_Window* sdlWindow, std::shared_ptr<Actor> actor_);
	~Scene0();
	bool OnCreate();
	void OnDestroy();
	void Update(const float time);
	void Render();
};

#endif

