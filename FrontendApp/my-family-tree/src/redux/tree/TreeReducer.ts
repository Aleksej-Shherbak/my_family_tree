import {Reducer} from "redux";
import {TreeListAction, TreeActionTypes} from "./TreeTypes";
import {Tree} from "../../models/Tree";

export interface TreesState {
    trees: Tree[]
}

const initialState: TreesState = {
    trees: []
};

export const TreeReducer: Reducer<TreesState, TreeListAction> = (state: TreesState = initialState, action: TreeListAction): TreesState => {
    switch (action.type) {
        case TreeActionTypes.TREE_FETCH_LIST:
            return {trees: action.trees}
        case TreeActionTypes.TREE_ADD:
            return {trees: [...state.trees, ...action.trees]}
        default:
            return state;
    }
}