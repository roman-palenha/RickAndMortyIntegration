SELECT
	t.id as ticket_id,
	t.departure_time,
	t.seat_number,
	pers.id as passenger_id,
	pers.first_name,
	pers.last_name,
	pers.phone_number,
	pers.email,
	p.nationality
FROM Tickets t
INNER JOIN Passengers p ON t.passenger_id = p.id
INNER JOIN Person pers ON p.person_id = pers.id