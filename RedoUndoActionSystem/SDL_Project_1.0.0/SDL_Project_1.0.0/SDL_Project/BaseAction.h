#ifndef BASEACTION_H
#define BASEACTION_H


//virtual base action class that serves as a template for all action classes
class BaseAction {

public:

	//actions have a do action method that will do their action on an actor
	virtual void DoAction() = 0;
	//actions have a reverseAction method that will do the reverse of the action on an actor
	virtual void ReverseAction() = 0;
};
#endif
