
#### Initialization Sequence
All connections execute the following AT command sequence:
1. `ATZ` - Reset device
2. `ATE0` - Echo off
3. `ATL0` - Linefeeds off
4. `ATS0` - Spaces off
5. `ATSP<protocol>` - Set protocol
6. `ATSH7DF` - Set header to 7DF (broadcast request to all ECUs)
7. `0100` - Request PID support (validation handshake)

**Response Validation:**
- Success: ECU responds with data
- Failure: Response contains `UNABLE`, `ERROR`, or `NO DATA`

---

## 🎯 IDENTIFIED SENSORS & PIDs

### 1. **RPM - Revolutions Per Minute**
| Property | Value |
|----------|-------|
| **PID Code** | `010C` |
| **Service** | `01` (Current Data) |
| **Data Length** | 2 bytes |
| **Formula** | `((A × 256) + B) / 4` |
| **Unit** | RPM |
| **Range** | 0 - 16,383.75 RPM |
| **Event Handler** | `RpmReceived(int)` |
| **Polling Interval** | 250 ms |
| **Location** | `OBD2Manager.cs` lines 118-123 |

**Calculation Example:**
- Raw bytes: `10 00` (hex)
- Calculation: `((0x10 × 256) + 0x00) / 4 = (4096) / 4 = 1024 RPM`

---

### 2. **Vehicle Speed**
| Property | Value |
|----------|-------|
| **PID Code** | `010D` |
| **Service** | `01` (Current Data) |
| **Data Length** | 1 byte |
| **Formula** | Direct value (A) |
| **Unit** | km/h |
| **Range** | 0 - 255 km/h |
| **Event Handler** | `SpeedReceived(double)` |
| **Polling Interval** | 250 ms |
| **Location** | `OBD2Manager.cs` lines 125-130 |

**Calculation Example:**
- Raw byte: `64` (hex) = 100 decimal
- Speed: `100 km/h`

---

### 3. **Engine Coolant Temperature**
| Property | Value |
|----------|-------|
| **PID Code** | `0105` |
| **Service** | `01` (Current Data) |
| **Data Length** | 1 byte |
| **Formula** | `A - 40` |
| **Unit** | °C (Celsius) |
| **Range** | -40 to +215 °C |
| **Event Handler** | `CoolantTempReceived(double)` |
| **Polling Interval** | 250 ms |
| **Location** | `OBD2Manager.cs` lines 132-137 |
| **Grid Display** | Diagnosis tab, Row 0 (PID 0105) |

**Calculation Example:**
- Raw byte: `50` (hex) = 80 decimal
- Temperature: `80 - 40 = 40°C`

**Display Format:** `{value:F1} °C`

---

### 4. **Throttle Position (TP)**
| Property | Value |
|----------|-------|
| **PID Code** | `0111` |
| **Service** | `01` (Current Data) |
| **Data Length** | 1 byte |
| **Formula** | `(A × 100) / 255` |
| **Unit** | % (Percentage) |
| **Range** | 0 - 100 % |
| **Event Handler** | `ThrottleReceived(double)` |
| **Polling Interval** | 250 ms |
| **Location** | `OBD2Manager.cs` lines 139-144 |

**Calculation Example:**
- Raw byte: `7F` (hex) = 127 decimal
- Throttle: `(127 × 100) / 255 = 49.8%`

---

### 5. **Engine Load (Calculated)**
| Property | Value |
|----------|-------|
| **PID Code** | `0104` |
| **Service** | `01` (Current Data) |
| **Data Length** | 1 byte |
| **Formula** | `(A × 100) / 255` |
| **Unit** | % (Percentage) |
| **Range** | 0 - 100 % |
| **Event Handler** | `EngineLoadReceived(double)` |
| **Polling Interval** | 250 ms |
| **Location** | `OBD2Manager.cs` lines 146-151 |
| **Grid Display** | Diagnosis tab, Row 1 (PID 0104) |

**Calculation Example:**
- Raw byte: `CC` (hex) = 204 decimal
- Engine Load: `(204 × 100) / 255 = 80%`

**Display Format:** `{value:F1} %`

---

### 6. **Intake Air Temperature (IAT)**
| Property | Value |
|----------|-------|
| **PID Code** | `010F` |
| **Service** | `01` (Current Data) |
| **Data Length** | 1 byte |
| **Formula** | `A - 40` |
| **Unit** | °C (Celsius) |
| **Range** | -40 to +215 °C |
| **Event Handler** | `IntakeAirTempReceived(double)` |
| **Polling Interval** | 250 ms |
| **Location** | `OBD2Manager.cs` lines 153-158 |
| **Grid Display** | Diagnosis tab, Row 2 (PID 010F) |

**Calculation Example:**
- Raw byte: `2A` (hex) = 42 decimal
- IAT: `42 - 40 = 2°C`

**Display Format:** `{value:F1} °C`

---

### 7. **Mass Air Flow (MAF)**
| Property | Value |
|----------|-------|
| **PID Code** | `0110` |
| **Service** | `01` (Current Data) |
| **Data Length** | 2 bytes |
| **Formula** | `((A × 256) + B) / 100` |
| **Unit** | g/s (grams per second) |
| **Range** | 0 - 655.35 g/s |
| **Event Handler** | `MafReceived(double)` |
| **Polling Interval** | 250 ms |
| **Location** | `OBD2Manager.cs` lines 160-165 |
| **Grid Display** | Diagnosis tab, Row 3 (PID 0110) |

**Calculation Example:**
- Raw bytes: `03 E8` (hex)
- Calculation: `((0x03 × 256) + 0xE8) / 100 = (768 + 232) / 100 = 10.00 g/s`

**Display Format:** `{value:F2} g/s`

---

### 8. **Fuel Pressure (FP)**
| Property | Value |
|----------|-------|
| **PID Code** | `010A` |
| **Service** | `01` (Current Data) |
| **Data Length** | 1 byte |
| **Formula** | `A × 3` |
| **Unit** | kPa (Kilopascals) |
| **Range** | 0 - 765 kPa |
| **Event Handler** | `FuelPressureReceived(double)` |
| **Polling Interval** | 250 ms |
| **Location** | `OBD2Manager.cs` lines 167-172 |
| **Grid Display** | Diagnosis tab, Row 4 (PID 010A) |

**Calculation Example:**
- Raw byte: `50` (hex) = 80 decimal
- Fuel Pressure: `80 × 3 = 240 kPa`

**Display Format:** `{value:F1} kPa`

---

## 📊 SENSOR SUMMARY TABLE

| # | Sensor Name | PID | Data Bytes | Unit | Range | Formula | Response Handler |
|---|-------------|-----|-----------|------|-------|---------|------------------|
| 1 | RPM | 010C | 2 | RPM | 0-16,383.75 | `(A×256+B)/4` | `RpmReceived(int)` |
| 2 | Vehicle Speed | 010D | 1 | km/h | 0-255 | `A` | `SpeedReceived(double)` |
| 3 | Coolant Temp | 0105 | 1 | °C | -40 to +215 | `A-40` | `CoolantTempReceived(double)` |
| 4 | Throttle Position | 0111 | 1 | % | 0-100 | `(A×100)/255` | `ThrottleReceived(double)` |
| 5 | Engine Load | 0104 | 1 | % | 0-100 | `(A×100)/255` | `EngineLoadReceived(double)` |
| 6 | Intake Air Temp | 010F | 1 | °C | -40 to +215 | `A-40` | `IntakeAirTempReceived(double)` |
| 7 | MAF Air Flow | 0110 | 2 | g/s | 0-655.35 | `(A×256+B)/100` | `MafReceived(double)` |
| 8 | Fuel Pressure | 010A | 1 | kPa | 0-765 | `A×3` | `FuelPressureReceived(double)` |

---

## 🔌 INTERFACE SPECIFICATIONS

### Serial Port Configuration
```csharp
SerialPort Configuration:
  - Baud Rate: 38,400 bps
  - Data Bits: 8 (standard)
  - Stop Bits: 1 (standard)
  - Parity: None (standard)
  - Handshaking: None
  - Line Ending: CR (\r)
  - Read Timeout: 2000 ms
  - Write Timeout: 2000 ms
