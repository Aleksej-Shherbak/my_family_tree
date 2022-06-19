import {Reducer} from "redux";
import {TreeAction, TreeActionTypes} from "./TreeTypes";
import {Tree} from "../../models/tree/Tree";

export interface TreeState {
    trees: Tree[]
}

const initialState: TreeState = {
    trees: []
};

export const TreeReducer: Reducer<TreeState, TreeAction> = (state: TreeState = initialState, action: TreeAction): TreeState => {
    switch (action.type) {
        case TreeActionTypes.TREE_GET_LIST:
            return {trees: action.trees}
        default:
            return state;
    }
}