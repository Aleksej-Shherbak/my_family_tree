import {Reducer} from "redux";
import {TreeListTypes, TreeTypes, TTree} from "./TreeTypes";
import {Tree} from "../../models/Tree";

export interface TreesState {
    isLoading: boolean,
    errorMessage: string,
    trees: Tree[]
}

const initialState: TreesState = {
    isLoading: false,
    errorMessage: '',
    trees: []
};

export const TreeReducer: Reducer<TreesState, TTree> = (state: TreesState = initialState, action: TTree): TreesState => {
    switch (action.type) {
        // tree list
        case TreeListTypes.REQUEST_STARTED:
            return {...state, isLoading: true}
        case TreeListTypes.REQUEST_SUCCEEDED:
            return {...state, isLoading: false, errorMessage: ''}
        case TreeListTypes.SET_LIST:
            return {...state, trees: action.payload}
        case TreeListTypes.REQUEST_FAILED:
            return {...state, errorMessage: action.payload}
        
        // tree
        case TreeTypes.REQUEST_STARTED:
            return {...state, isLoading: true};
        case TreeTypes.ADD:
            return {...state, trees: [...state.trees, action.payload]};
        case TreeTypes.EDIT:
            return {...state, trees: [
                ...state.trees.filter(({ id }) => id !== action.payload.id),
                action.payload
            ]}
        case TreeTypes.DELETE:
            return {...state, trees: [
                ...state.trees.filter(({ id }) => id !== action.payload.id),
            ]}
        case TreeTypes.REQUEST_SUCCEEDED:
            return {...state, isLoading: false, errorMessage: ''}
        case TreeTypes.REQUEST_FAILED:
            return {...state, errorMessage: action.payload}
        default:
            return state;
    }
}