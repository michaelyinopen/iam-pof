import React, { useState, useEffect } from 'react';
import { useAuth0 } from "../react-auth0-spa";

function renderForecastsTable(forecasts) {
  return (
    <table className='table table-striped' aria-labelledby="tabelLabel">
      <thead>
        <tr>
          <th>Date</th>
          <th>Temp. (C)</th>
          <th>Temp. (F)</th>
          <th>Summary</th>
        </tr>
      </thead>
      <tbody>
        {forecasts.map(forecast =>
          <tr key={forecast.date}>
            <td>{forecast.date}</td>
            <td>{forecast.temperatureC}</td>
            <td>{forecast.temperatureF}</td>
            <td>{forecast.summary}</td>
          </tr>
        )}
      </tbody>
    </table>
  );
}

const FetchData = () => {
  const [state, setState] = useState({ forecasts: [], loading: true });
  const { getTokenSilently } = useAuth0();
  useEffect(
    () => {
      const populateWeatherData = async () => {
        try {
          const token = await getTokenSilently();
          const response = await fetch('weatherforecast', {
            headers: {
              Authorization: `Bearer ${token}`
            }
          });
          const data = await response.json();
          setState({ forecasts: data, loading: false });
        } catch (error) {
          console.error(error);
        }
      };
      populateWeatherData();
    },
    [getTokenSilently]
  );

  let contents = state.loading
    ? <p><em>Loading...</em></p>
    : renderForecastsTable(state.forecasts);

  return (
    <div>
      <h1 id="tabelLabel" >Weather forecast</h1>
      <p>This component demonstrates fetching data from the server.</p>
      {contents}
    </div>
  );
};

export default FetchData;