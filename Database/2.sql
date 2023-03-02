SELECT TOP 5
	t.id,
	t.departure_time,
	t.passenger_id,
	t.seat_number
FROM Payments p
INNER JOIN Tickets t on p.ticket_id = t.id
ORDER BY p.payment_date DESC 
