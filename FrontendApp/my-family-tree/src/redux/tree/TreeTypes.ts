import {AnyAction} from "redux";
import { Tree } from "../../models/tree/Tree";

export interface TreeAction extends AnyAction {
    trees: Tree[]
}

export enum TreeActionTypes {
    TREES_LOADING = 'TREES_LOADING',
    TREES_LOADING_FINISHED = 'TREES_LOADING_FINISHED',
    TREE_GET_LIST = 'TREE_GET_LIST',
    TREE_ADD = 'TREE_ADD',
    TREE_DELETE = 'TREE_DELETE',
    TREE_EDIT = 'TREE_EDIT',
}