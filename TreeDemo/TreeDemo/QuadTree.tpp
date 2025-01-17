template <class T>
QuadTree<T>::QuadTree() {

}

template <class T>
QuadTree<T>::QuadTree(std::vector<float> topLB_, std::vector<float> botRB_) {

	topLBound = topLB_;
	botRBound = botRB_;
	node = NULL;
	nodes = std::vector<CoordNode<T>*>();

	topLQuad = NULL;
	topRQuad = NULL;
	botLQuad = NULL;
	botRQuad = NULL;
}

template<class T>
void QuadTree<T>::InsertNode(CoordNode<T>* qnode_)
{
	//check if a valid node is being passed
	if (qnode_ == NULL) {
		return;
	}

	//check to make sure if the node is within the bounds of this quadrant
	if (!inBound(qnode_->coordinate)) {
		return;
	}

	if (divided) {
		topLQuad->InsertNode(qnode_);
		topRQuad->InsertNode(qnode_);
		botLQuad->InsertNode(qnode_);
		botRQuad->InsertNode(qnode_);
		return;
	}

	if (nodes.empty()) {
		nodes = std::vector<CoordNode<T>*>();
		nodes.push_back(qnode_);
		std::cout << "Node was Added" << std::endl;
		return;
	}

	if (nodes.size() < size) {
		nodes.push_back(qnode_);
		std::cout << "Node was Added" << std::endl;
		return;
	}
	else {
		Divide();
		return;
	}
}



template<class T>
CoordNode<T>* QuadTree<T>::Find(std::vector<float> coord_) {
	//check if its in the quad
	if (!inBound(coord_)) {
		return NULL;
	}

	if (node != NULL) {
		return node;
	}

	if ((topLBound[0] + botRBound[0]) / 2 >= coord_[0]) {
		// check topleftquad
		if ((topLBound[1] + botRBound[1]) / 2 >= coord_[1]) {
			if (topLQuad == NULL) {
				return NULL;
			}
			return topLQuad->Find(coord_);
		}

		//check botleftquad
		else {
			if (botLQuad == NULL) {
				return NULL;
			}
			return botLQuad->Find(coord_);
		}
	}
	else {
		// check topRQuad 
		if ((topLBound[1] + botRBound[1]) / 2 >= coord_[1]) {
			if (topRQuad == NULL) {
				return NULL;
			}
			return topRQuad->Find(coord_);
		}

		// check botRQuad
		else {
			if (botRQuad == NULL) {
				return NULL;
			}
			return botRQuad->Find(coord_);
		}
	}
}

template<class T>
std::vector<CoordNode<T>*> QuadTree<T>::FindInRadius(std::vector<float> coord_, float radius) {
	return std::vector<CoordNode<T>*>();
}

template<class T>
bool QuadTree<T>::inBound(std::vector<float> coord_) {
	return (coord_[0] >= topLBound[0] && coord_[0] <= botRBound[0] && coord_[1] >= topLBound[1]
		&& coord_[1] <= botRBound[1]);
}

//TODO Implement Divide
template<class T>
void QuadTree<T>::Divide() {
	//check if we cannot subdivide this quadrant any further
	if (abs(topLBound[0] - botRBound[0]) <= 1 && abs(topLBound[1] - botRBound[1]) <= 1) {
		//Todo: figure out some else to implement here for when the quadrant cant be divided further and is full
		return;
	}
	if (topLQuad == NULL) {
		std::vector<float> newbound;
		newbound.push_back((topLBound[0] + botRBound[0]) / 2);
		newbound.push_back((topLBound[1] + botRBound[1]) / 2);

		topLQuad = new QuadTree(topLBound, newbound);
		std::cout << "Top L Quad Made \n";
		for (int i = 0; i < nodes.size(); i++) {
			topLQuad->InsertNode(nodes[i]);
		}
	}

	//checking for botleft quadrant
	if (botLQuad == NULL) {
		std::vector<float> newLbound;
		newLbound.push_back(topLBound[0]);
		newLbound.push_back((topLBound[1] + botRBound[1]) / 2);

		std::vector<float> newRbound;
		newRbound.push_back((topLBound[0] + botRBound[0]) / 2);
		newRbound.push_back(botRBound[1]);

		botLQuad = new QuadTree(newLbound, newRbound);
		std::cout << "Bot L Quad Made \n";
		for (int i = 0; i < nodes.size(); i++) {
			botLQuad->InsertNode(nodes[i]);
		}
	}
	//checking for topright quad
	if (topRQuad == NULL) {
		std::vector<float> newLbound;
		newLbound.push_back((topLBound[0] + botRBound[0]) / 2);
		newLbound.push_back(topLBound[1]);

		std::vector<float> newRbound;
		newRbound.push_back(botRBound[0]);
		newRbound.push_back((topLBound[1] + botRBound[1]) / 2);

		topRQuad = new QuadTree(newLbound, newRbound);
		std::cout << "Top R Quad Made \n";
		for (int i = 0; i < nodes.size(); i++) {
			topRQuad->InsertNode(nodes[i]);
		}

	}
	//checking for botright quad
	if (botRQuad == NULL) {
		std::vector<float> newLbound;
		newLbound.push_back((topLBound[0] + botRBound[0]) / 2);
		newLbound.push_back((topLBound[1] + botRBound[1]) / 2);

		botRQuad = new QuadTree(newLbound, botRBound);
		std::cout << "Bot R Quad Made \n";
		for (int i = 0; i < nodes.size(); i++) {
			botRQuad->InsertNode(nodes[i]);
		}

	}

	divided = true;
	nodes = std::vector<CoordNode<T>*>();
}