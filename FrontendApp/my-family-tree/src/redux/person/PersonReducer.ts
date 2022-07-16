import {Reducer} from "redux";
import {PersonActionTypes, PersonsAction} from "./PersonTypes";
import {Person} from "../../models/Person";

export interface PersonState {
    persons: Person[]
}

const initialState: PersonState = {
    persons: []
};

export const PersonReducer: Reducer<PersonState, PersonsAction> = 
    (state: PersonState = initialState, action: PersonsAction): PersonState => {
    switch (action.type) {
        case PersonActionTypes.PERSONS_FETCH:
            return {persons: action.persons}
        default:
            return state;
    }
}