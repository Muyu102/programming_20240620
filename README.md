# 使用 C# 設計一個寶可夢的類別繼承體系

### 1. 列舉

* 設計一個名為 `Property` 的列舉，包含至少以下成員：
    * `Normal` (普通)
    * `Fire` (火)
* 設計一個名為 `Skill` 的列舉，包含至少以下成員（依照期末考 UML 圖所示）：
    * `噴射火焰`
    * `捨身衝撞`
    * `火焰牙`
    * `閃焰衝鋒`

### 2. 抽象類別: `Pokemon`

* 設計一個 `public abstract` 類別 `Pokemon`。
* 包含以下 **protected** 屬性 (可讀取，由類別或子類別設定)：
    * `Name` (`string`): 寶可夢名稱。
    * `Property` (`Property`): 寶可夢屬性。
    * `Health` (`int`): 寶可夢血量。
    * `Skill` (`Skill`): 寶可夢的主要招式。
    * `Power` (`double`): 寶可夢的基礎威力值。
* **建構子 (Constructors):**
    * 一個預設建構子。
    * 一個接受 `name` (`string`) 參數的建構子。
    * **行為：** 在建構時，`Health` 屬性應隨機給予 0 到 100 之間的整數亂數。可設定合理的預設值給 `Name`, `Property`, `Skill`, `Power`，或由衍生類別設定。
* **抽象方法 (Abstract Method):**
    * `public abstract string GuessWhoAmI();` - 用於顯示寶可夢的資訊，必須由衍生類別實作。
* **虛擬方法 (Virtual Method):**
    * `public virtual string Attack();` - 用於執行攻擊，提供一個基礎實作，允許衍生類別覆寫。

### 3. 介面

* 設計一個 `public` 介面 `INormalType`。
    * 要求實作 `GuessWhoAmI()` 方法的簽章。
* 設計一個 `public` 介面 `IFireType`。
    * 此介面繼承自 `INormalType`。
    * 額外要求實作 `Attack()` 方法的簽章。

### 4. 具體類別

* **`Charmander` (小火龍):**
    * 繼承自 `Pokemon` 類別。
    * 實作 `IFireType` 介面。
    * 屬性設定為 `Property.Fire`。
    * 需實作 `GuessWhoAmI()` 和覆寫 `Attack()` 方法。
* **`Eevee` (伊布):**
    * 繼承自 `Pokemon` 類別。
    * 實作 `INormalType` 介面。
    * 屬性設定為 `Property.Normal`。
    * 需實作 `GuessWhoAmI()` 方法。（可選擇性覆寫 `Attack()`，否則使用基底版本）。
* **`Flareon` (火伊布):**
    * 繼承自 `Eevee` 類別。
    * 實作 `IFireType` 介面。
    * 屬性設定為 `Property.Fire`。
    * 需覆寫 `GuessWhoAmI()` 和 `Attack()` 方法。
* **`Charmeleon` (火恐龍):**
    * 繼承自 `Charmander` 類別。
    * 實作 `IFireType` 介面 (透過繼承 Charmander)。
    * 屬性為 `Property.Fire` (繼承自 Charmander)。
    * 需覆寫 `GuessWhoAmI()` 和 `Attack()` 方法。

### 5. 方法行為要求

* `GuessWhoAmI()` 方法：執行時，應在主控台 (Console) 或以字串形式返回該寶可夢的相關資訊 (例如：名稱、屬性、血量、招式等)。
* `Attack()` 方法：執行時，應在主控台 (Console) 或以字串形式返回攻擊訊息，訊息中應包含該寶可夢的名稱及其使用的招式 (最好使用 `Skill` 屬性)，並顯示目前的剩餘血量 (`Health`)。

### 6. UML 圖提示

* 所有類別中的屬性、方法、建構子均應盡量依照**期末考 UML 圖** 中所提示的方式進行設計（例如存取修飾詞、參數、回傳型別等）。允許使用 C# 的慣用寫法，例如使用屬性 (`{ get; protected set; }`) 取代明確的 Get/Set 方法。
