import * as React from 'react';
import {FC} from 'react';
import styles from './NotAuthorizedLayout.module.scss';
import IChildrenContainer from "../../infrastructure/IChildrenContainer";

const NotAuthorizedLayout: FC<IChildrenContainer> = ({children}) => {
    return (
        <div className={styles.notAuthorizedLayout}>
            {children}
        </div>
    );
};

export default NotAuthorizedLayout;