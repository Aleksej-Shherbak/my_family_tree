import {Reducer} from "redux";
import {Person} from "../../models/Person";
import {PersonListTypes, PersonTypes, TPerson} from "./PersonTypes";

export interface PersonState {
    persons: Person[],
    isLoading: boolean,
    errorMessage: string
}

const initialState: PersonState = {
    persons: [],
    isLoading: false,
    errorMessage: ''
};

export const PersonReducer: Reducer<PersonState, TPerson> = 
    (state: PersonState = initialState, action: TPerson): PersonState => {
    switch (action.type) {
        // List
        case PersonListTypes.SET_LIST:
            return {...state, persons: action.payload}
        case PersonListTypes.REQUEST_SUCCEEDED:
            return {...state, isLoading: false, errorMessage: ''}
        case PersonListTypes.REQUEST_STARTED:
            return {...state, isLoading: true}
        case PersonListTypes.REQUEST_FAILED:
            return {...state, isLoading: false, errorMessage: action.payload}
        
        // Item
        case PersonTypes.REQUEST_STARTED:
            return {...state, isLoading: true}
        case PersonTypes.REQUEST_SUCCEEDED:
            return {...state, isLoading: false, errorMessage: ''}
        case PersonTypes.REQUEST_FAILED:
            return {...state, isLoading: false, errorMessage: action.payload}
        case PersonTypes.ADD:
            return {...state, persons: [...state.persons, action.payload]}
        case PersonTypes.EDIT:
            return {
                ...state,
                persons: [...state.persons.filter(({id}) => id !== action.payload.id), action.payload]
            }
        case PersonTypes.DELETE:
            return {
                ...state,
                persons: [...state.persons.filter(({id}) => id !== action.payload.id)]
            }
        default:
            return state;
    }
}