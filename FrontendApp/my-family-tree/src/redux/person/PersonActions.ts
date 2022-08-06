import {Dispatch} from "redux";
import {alertActions} from "../alert/AlertActions";
import {AlertAction} from "../alert/AlertTypes";
import {GET_PERSON_LIST} from "../../constants/backend";
import {MakeRequest} from "../../infrastructure/http/MakeRequest";
import {Person} from "../../models/Person";
import {PersonListTypes, TPerson} from "./PersonTypes";

export const personActions = {
    fetchList,
//    create
}

function fetchList() {
    return async (dispatch: Dispatch<TPerson | AlertAction>): Promise<void> => {
        try {
            dispatch({type: PersonListTypes.REQUEST_STARTED});
            const res = await MakeRequest<Person[]>(GET_PERSON_LIST, 'GET');
            if (res !== null) {
                dispatch({type: PersonListTypes.SET_LIST, payload: res.data});
                dispatch({type: PersonListTypes.REQUEST_SUCCEEDED});
            }
        } catch (error) {
            dispatch({type: PersonListTypes.REQUEST_FAILED, payload: 'Failed to fetch person list.'});
            console.error(error);
            await dispatch(alertActions.error('Unable to load persons. Please try again later.'));
        }
    }
    
}

/*function create(request: CreateTreeRequest) {
    return async (dispatch: Dispatch<TreeListAction | AlertAction>): Promise<void> => {
        try {
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
            dispatch(success([tree]));
        } catch (error) {
            console.error(error);
            await dispatch(alertActions.error('Unable to load create new tree. Please try again later.'));
        }
    }

    function success(trees: Tree[]): TreeListAction {
        return {type: TreeListActionTypes.TREE_ADD, trees};
    }
}*/
