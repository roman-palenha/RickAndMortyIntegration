SELECT TOP 3
	COUNT(f.id) as flights_amount,
	t.passenger_id
FROM Flights f
INNER JOIN Tickets t on f.id = t.flight_id
GROUP BY t.passenger_id
ORDER BY flights_amount DESC