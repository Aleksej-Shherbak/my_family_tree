import {Reducer} from "redux";
import {TreeListAction, TreeListActionTypes} from "./TreeTypes";
import {Tree} from "../../models/tree/Tree";

export interface TreeListState {
    trees: Tree[]
}

const initialState: TreeListState = {
    trees: []
};

export const TreeListReducer: Reducer<TreeListState, TreeListAction> = (state: TreeListState = initialState, action: TreeListAction): TreeListState => {
    switch (action.type) {
        case TreeListActionTypes.TREE_FETCH_LIST:
            return {trees: action.trees}
        default:
            return state;
    }
}