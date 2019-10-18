#include "QuadTree.h"
#include "KDTree.h"

int main(int argc, char* argv[]) {
	std::vector<float> coordinate;
	std::vector<float> topbound;
	std::vector<float> lowbound;
	topbound.push_back(0.0f);
	topbound.push_back(0.0f);
	lowbound.push_back(50.0f);
	lowbound.push_back(50.0f);
	coordinate.push_back(0.0f);
	coordinate.push_back(0.0f);
	int data = 1;
	std::vector<float> coordinate1;
	coordinate1.push_back(0.0f);
	coordinate1.push_back(0.0f);
	coordinate1.push_back(0.0f);

	QuadTree<int>* tree = new QuadTree<int>(topbound, lowbound);
	KDTree<int>* kdTree = new KDTree<int>(new CoordNode<int>(coordinate1, data), 0);

	for (int i = 0; i < 40; i++) {
		coordinate[1] += 1.0f;
		coordinate[0] += 1.0f;
		if (i < 20) {
			coordinate1[2] += 1.0f;
			coordinate1[1] += 1.0f;
			coordinate1[0] += 1.0f;
		}
		else {
			coordinate1[2] += 1.0f;
			coordinate1[1] -= 1.0f;
			coordinate1[0] += 1.0f;
		}
		CoordNode<int>* node = new CoordNode<int>(coordinate, data);
		CoordNode<int>* node1 = new CoordNode<int>(coordinate1, data);
		tree->InsertNode(node);
		kdTree->InsertNode(node1);
	}

	return 0;
}
