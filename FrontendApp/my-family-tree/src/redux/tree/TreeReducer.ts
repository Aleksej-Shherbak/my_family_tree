import {Reducer} from "redux";
import {TreeListAction, TreeListActionTypes} from "./TreeTypes";
import {Tree} from "../../models/tree/Tree";

export interface TreesState {
    trees: Tree[]
}

const initialState: TreesState = {
    trees: []
};

export const TreeReducer: Reducer<TreesState, TreeListAction> = (state: TreesState = initialState, action: TreeListAction): TreesState => {
    switch (action.type) {
        case TreeListActionTypes.TREE_FETCH_LIST:
            return {trees: action.trees}
        case TreeListActionTypes.TREE_ADD:
            return {trees: [...state.trees, ...action.trees]}
        default:
            return state;
    }
}