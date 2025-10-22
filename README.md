# 🏨 Hotel Booking API

A small **C# Web API** to manage **rooms** and **bookings** for a hotel.

---

## 📑 Table of Contents

- [Overview](#overview)  
- [Requirements](#requirements)  
- [Getting Started](#getting-started)  
- [API Endpoints](#api-endpoints)  
- [Domain Rules](#domain-rules)  
- [Edge Cases](#edge-cases)  
- [Assumptions](#assumptions)  
- [Tests](#tests)  

---

## 🏗 Overview

This project implements a **simple hotel room and booking management system** using **ASP.NET Core Web API**.  

- Data is stored **in-memory**. (SQLite not done yet)
- **Swagger/OpenAPI UI** is the landing page in development.  

It supports:

- ✅ Adding rooms  
- ✅ Booking rooms  
- ✅ Checking availability  
- ✅ Listing bookings for a room  

---

## ⚙ Requirements

- **.NET 8** (7+ acceptable)  
- **ASP.NET Core Web API**  
- **In-memory storage** (List)  
- **Swagger/OpenAPI** via Swashbuckle  

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)  
- IDE: VS 2022 / VS Code / Rider  

### Build & Run


### 1. Clone the repo

<pre><code class="bash">
git clone https://github.com/rauszka/HotelBookingAPI
cd HotelBookingAPI
</code></pre>

### 2. Restore dependencies

<pre><code class="bash">
dotnet restore
</code></pre>

### 3. Build the project

<pre><code class="bash">
dotnet build
</code></pre>

### 4. Run the API

<pre><code class="bash">
dotnet run
</code></pre>

### 5. Open Swagger UI in Development

<pre><code class="arduino">
http://localhost:5276/swagger
</code></pre>

> Swagger provides interactive API documentation and allows testing endpoints.

---

## 🛠 API Endpoints

### 1️⃣ Add Room

**POST** `/api/rooms`

**Request Body:**

<pre><code class="json">
{ "name": "Deluxe 101" }
</code></pre>

**Response:**

<pre><code class="json">
{
  "id": "int-here",
  "name": "Deluxe 101"
}
</code></pre>

---

### 2️⃣ Book a Room

**POST** `/api/rooms/{roomId}/bookings`

**Request Body:**

<pre><code class="json">
{
  "guestName": "Jane Doe",
  "fromDate": "2025-10-10",
  "toDate": "2025-10-13"
}
</code></pre>

**Response:**

<pre><code class="json">
{
  "id": "int-here",
  "roomId": "room-int-here",
  "guestName": "Jane Doe",
  "fromDate": "2025-10-10",
  "toDate": "2025-10-13"
}
</code></pre>

---

### 3️⃣ Check Availability

**GET** `/api/availability?from=2025-10-10&to=2025-10-13`

**Response:**

<pre><code class="json">
[
  { "id": "room1-int", "name": "Deluxe 101" },
  { "id": "room2-int", "name": "Suite 202" }
]
</code></pre>

---

### 4️⃣ List Bookings of a Room

**GET** `/api/rooms/{roomId}/bookings`

**Response:**

<pre><code class="json">
[
  {
    "id": "booking-int",
    "roomId": "room-int-here",
    "guestName": "Jane Doe",
    "fromDate": "2025-10-10",
    "toDate": "2025-10-13"
  }
]
</code></pre>

---

## 📌 Domain Rules

- **Room:** `{ Id, Name }`  
- **Booking:** `{ Id, RoomId, GuestName, FromDate, ToDate }`  
- **Date semantics:** FromDate inclusive, ToDate exclusive  
- **No overlaps** within the same room  
- **All dates** are UTC (ISO-8601)  

---

## ⚠ Edge Cases

- Overlap checks: touching edges allowed ✔  
- Invalid ranges: FromDate >= ToDate → returns error ❌  
- Nonexistent room: returns Room not found ❌  
- Duplicate room name: checked in repository → error ❌  
- Concurrency safety: optional in-memory lock for thread-safe booking ⚡(Not done yet)  

---

## 💡 Assumptions

- In-memory repository → no persistence beyond runtime  
- Room Id is int, generated in repository  
- Booking Id is int  
- Service layer handles business logic; repository only stores and retrieves entities  
- All dates in requests/responses are UTC  
