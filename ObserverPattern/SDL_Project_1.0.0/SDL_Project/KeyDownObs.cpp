#include "KeyDownObs.h"
#include "Subject.h"

void KeyDownObs::Update(Subject * subject_, SDL_Event event_) {
	if (event_.type == SDL_KEYDOWN) {
		std::cout << "I SAW A KEYDOWN FROM " << subject_->getName() << std::endl;
	}
}
