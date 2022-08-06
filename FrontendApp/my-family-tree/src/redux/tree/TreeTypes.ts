import {Tree} from "../../models/Tree";

// Tree list
export enum TreeListTypes {
    REQUEST_STARTED = 'TREE_LIST_REQUEST_STARTED',
    REQUEST_SUCCEEDED = 'TREE_LIST_REQUEST_SUCCEEDED',
    REQUEST_FAILED = 'TREE_LIST_REQUEST_FAILED',
    SET_TREE_LIST = 'TREE_LIST_SET',
}

export type TTreeList =
    |
    {
        type: TreeListTypes.REQUEST_STARTED
    }
    |
    {
        type: TreeListTypes.REQUEST_SUCCEEDED
    }
    |
    {
        type: TreeListTypes.SET_TREE_LIST
        payload: Tree[]
    }
    |
    {
        type: TreeListTypes.REQUEST_FAILED,
        payload: string
    };

// Tree item
export enum TreeTypes {
    REQUEST_STARTED = 'TREE_REQUEST_STARTED',
    REQUEST_SUCCEEDED = 'TREE_REQUEST_SUCCEEDED',
    ADD = 'TREE_ADD',
    DELETE = 'TREE_DELETE',
    EDIT = 'TREE_EDIT',
    REQUEST_FAILED = 'TREE_REQUEST_FAILED',
}

export type TTreeItem =
    |
    {
        type: TreeTypes.REQUEST_STARTED,
    }
    |
    {
        type: TreeTypes.REQUEST_SUCCEEDED,
    }
    |
    {
        type: TreeTypes.ADD,
        payload: Tree
    }
    |
    {
        type: TreeTypes.DELETE,
        payload: Tree
    }
    |
    {
        type: TreeTypes.EDIT,
        payload: Tree
    }
    |
    {
        type: TreeTypes.REQUEST_FAILED,
        payload: string
    };

export type TTree = 
    TTreeList |
    TTreeItem;