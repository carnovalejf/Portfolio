#include "ArrowKeyObs.h"
#include "Subject.h"

void ArrowKeyObs::Update(Subject * subject_, SDL_Event event_) {
	if (event_.key.keysym.sym == SDLK_UP || event_.key.keysym.sym == SDLK_DOWN
		|| event_.key.keysym.sym == SDLK_LEFT || event_.key.keysym.sym == SDLK_RIGHT) {
		std::cout << "I SAW AN ARROW KEY FROM " << subject_->getName() << std::endl;
	}
}
