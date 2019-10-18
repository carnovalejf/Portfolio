#ifndef ACTION_H
#define ACTION_H

#include <memory>
#include "BaseAction.h"

//base action class that does not implement anything but extends BaseAction and serves as a concrete definition of Action
class Action : public BaseAction{

public:
	Action();
	~Action();
	//actions have a do action method that will do their action on an actor
	void DoAction();
	//actions have a reverseAction method that will do the reverse of the action on an actor
	void ReverseAction();
};
#endif