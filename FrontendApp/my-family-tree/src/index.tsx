import React from 'react';
import ReactDOM from 'react-dom/client';
import {app} from './App';
import reportWebVitals from './reportWebVitals';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <React.StrictMode>
      {app}
  </React.StrictMode>
);

reportWebVitals();
