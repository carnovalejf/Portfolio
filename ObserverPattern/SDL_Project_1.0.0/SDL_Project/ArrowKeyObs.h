#pragma once
#include "Observer.h"

//arrow key observer class, it extends the base observer and serves as an observer that is only interested
//in arrow key down events, and will only act if the event it was notified of was a arrow key
class ArrowKeyObs : public Observer{
public:
	//arrowkeyobs own personal update method that will take in the subject and the event, and will respond if
	//it is a arrow key down event that was observed and will announce which subject it observed it from
	void Update(Subject * subject_, SDL_Event event_);
};
