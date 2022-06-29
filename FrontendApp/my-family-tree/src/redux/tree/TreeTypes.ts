import {AnyAction} from "redux";
import { Tree } from "../../models/tree/Tree";

export interface TreeListAction extends AnyAction {
    trees: Tree[]
}

export interface TreeAction extends AnyAction {
    tree: Tree
}

export enum TreeListActionTypes {
    TREES_LOADING = 'TREES_LOADING',
    TREES_LOADING_FINISHED = 'TREES_LOADING_FINISHED',
    TREE_FETCH_LIST = 'TREE_FETCH_LIST',
    TREE_ADD = 'TREE_ADD',
    TREE_DELETE = 'TREE_DELETE',
    TREE_EDIT = 'TREE_EDIT',
}

export enum TreeActionTypes {
    TREE_CREATE = 'TREE_CREATE',
    TREE_DELETE = 'TREE_DELETE',
    TREE_EDIT = 'TREE_EDIT',
}