import {Dispatch} from "redux";
import {TTree, TreeTypes, TreeListTypes} from "./TreeTypes";
import axios, {AxiosResponse} from "axios";
import {alertActions} from "../alert/AlertActions";
import {AlertAction} from "../alert/AlertTypes";
import {BASE_URL, CREATE_TREE, GET_TREE_LIST} from "../../constants/backend";
import {CreateTreeRequest} from "../../Requests/Tree/CreateTreeRequest";
import {TreeResponse} from "../../Responses/tree/TreeResponse";
import {MakeRequest} from "../../infrastructure/http/MakeRequest";
import {Tree} from "../../models/Tree";

export const treeActions = {
    treeFetchList,
    createTree
}

function treeFetchList() {
    return async (dispatch: Dispatch<TTree | AlertAction>): Promise<void> => {
        try {
            dispatch({type: TreeListTypes.REQUEST_STARTED});
            const res = await MakeRequest<Tree[]>(GET_TREE_LIST, 'GET');
            if (res !== null) {
                dispatch({type: TreeListTypes.SET_TREE_LIST, payload: res.data});
                dispatch({type: TreeListTypes.REQUEST_SUCCEEDED});
            }
        } catch (error) {
            dispatch({type: TreeListTypes.REQUEST_FAILED, payload: 'Failed to load tree list'});
            console.error(error);
            await dispatch(alertActions.error('Unable to load trees. Please try again later.'));
        }
    }
}

function createTree(request: CreateTreeRequest) {
    return async (dispatch: Dispatch<TTree | AlertAction>): Promise<void> => {
        try {
            dispatch({type: TreeTypes.REQUEST_STARTED});
            const bodyFormData = new FormData();
            if (request.image) {
                bodyFormData.append('image', request.image)
            }
            bodyFormData.append('title', request.title)
            if (request.description) {
                bodyFormData.append('description', request.description)
            }

            const res = await axios.post<CreateTreeRequest, AxiosResponse<TreeResponse>>(`${BASE_URL}${CREATE_TREE}`, bodyFormData, {withCredentials: true});
            const tree: Tree = {...res.data}
            dispatch({type: TreeTypes.ADD, payload: tree});
            dispatch({type: TreeTypes.REQUEST_SUCCEEDED});
        } catch (error) {
            dispatch({type: TreeTypes.REQUEST_FAILED, payload: 'Failed to create Tree.'})
            console.error(error);
            await dispatch(alertActions.error('Unable to load create new tree. Please try again later.'));
        }
    }
}
