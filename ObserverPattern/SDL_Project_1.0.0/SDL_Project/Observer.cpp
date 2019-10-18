#include "Observer.h"
#include "Subject.h"
#include <algorithm>


Observer::Observer() {
	//initialize member variables
	subjects = std::make_unique<std::vector<Subject *>>(std::vector<Subject *>());
}

void Observer::Subscribe(Subject * subject_) {
	subjects->push_back(subject_);
	subject_->Attach(this);

}

void Observer::UnSubscribe(Subject * subject_) {
	
	subject_->Detach(this);
	subjects->erase(std::remove(subjects->begin(), subjects->end(), subject_), subjects->end());
	std::cout << "Unsubscribed from " << subject_->getName() << std::endl;

}
