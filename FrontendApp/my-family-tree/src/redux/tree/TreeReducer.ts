import {Reducer} from "redux";
import {TreeAction, TreeActionTypes} from "./TreeTypes";
import {Tree} from "../../models/tree/Tree";

export interface TreeState {
    tree: Tree|null
}

const initialState: TreeState = {
    tree: null
};

export const TreeListReducer: Reducer<TreeState, TreeAction> = (state: TreeState = initialState, action: TreeAction): TreeState => {
    switch (action.type) {
        case TreeActionTypes.TREE_CREATE:
            return {tree: action.tree}
        default:
            return state;
    }
}