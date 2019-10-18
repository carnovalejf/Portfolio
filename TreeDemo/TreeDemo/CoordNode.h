#ifndef COORDNODE_H
#define COORDNODE_H

#include <vector>
template <class T>
struct CoordNode {
	std::vector<float> coordinate;
	T value;
		
	CoordNode(std::vector<float> coordinates_, T data_) {
		coordinate = coordinates_;
		value = data_;
	};
};
#endif // !COORDNODE_H
