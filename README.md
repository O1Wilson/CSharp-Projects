Ok this a great response format, now let me detail you the melee system I want you to write this guide for (please use the same format). The foundations of the system should include player health, stamina, and armor. The melee system has four main systems (Attack Style, Combo's, Parrying/Riposte, Attack Manipulation's) Mechanics include (disarming, feint/morph windows, riposting, parrying, combo speed)

Attack Style: There are four attack styles each displaying their own animations
Thrust, Slash, Overhead, Underhanded
Each attack style should have their own unique damage values, and stamina drain
these values will be dependant on the weapon used aswell

Combo's: When performing successive attacks, each subsequent attack should do two things:
1. Increase in speed; This involves increasing the speed at which the animation lasts
2. Increase in stamina cost; This should be a small increase in stamina cost per repeat attack

Parrying: Parrying an attack could resolve in many cases:
1. Successful parry should stop the attack and drain the stamina from the parrier, resulting in a parried animation for the attacker and very short cooldown on their next attack, then open a "Riposte" window for the Parrier that will speed up their next attack and use less stamina 
2. Failed parry should replace the parrying animation with a hit animation and not drain any stamina from the parry
3. Successful parry but lack of stamina: if a parry is made with not enough required stamina, the parry will go through, but the item used for parry will be disarmed
4. You can parry during the feint/morph window.

Attack Manipulation: The player should have the ability to manipulate their attacks as so:
1. Feinting: Each attack will have a feint/morph window, the user can press the feint button to cancel the current attack, and rewind the animation. Any input can be accepted in the attack rewind. Feinting does not refund the used stamina from the initial attack
2. Morphing: Each attack will have a feint/morph window, the user can morph their attack by inputing a different attack style in this window. You can only morph once in the same attack, morphing uses stamina for both attack styles. The animation will morph into the other style and go through, NOTE: you can still cancel a morphed attack with feint or parry.


Lets please do this one system at a time: start with Attack Styles


Absolutely, let's break down the implementation of the **Attack Styles** system step by step. We’ll start from scratch and build up each component needed to handle the four attack styles: Thrust, Slash, Overhead, and Underhanded.

### **Step-by-Step Guide to Implementing Attack Styles**

#### **1. Create Attack Style Enumeration**

**Question:**
To manage different attack styles, we need an enumeration to represent each style. This will allow us to easily differentiate between Thrust, Slash, Overhead, and Underhanded when performing attacks and applying their respective properties.

**Code Snippet:**

**AttackStyles.h**
```cpp
#pragma once

#include "CoreMinimal.h"
#include "UObject/NoExportTypes.h"
#include "AttackStyles.generated.h"

UENUM(BlueprintType)
enum class EAttackStyle : uint8
{
    Thrust UMETA(DisplayName = "Thrust"),
    Slash UMETA(DisplayName = "Slash"),
    Overhead UMETA(DisplayName = "Overhead"),
    Underhanded UMETA(DisplayName = "Underhanded")
};
```

**Explanation:**
- `UENUM(BlueprintType)`: Declares the enumeration to be usable in Blueprints and Unreal Engine’s editor.
- `enum class EAttackStyle : uint8`: Defines an enumeration class for attack styles with underlying type `uint8` for efficient storage.
- `Thrust`, `Slash`, `Overhead`, `Underhanded`: The different attack styles we will use. `UMETA(DisplayName = "Name")` provides readable names for the editor.

#### **2. Declare Attack Style Properties in Combat Character**

**Question:**
With our attack styles defined, we need to add properties to the `CombatCharacter` class to store the current attack style and its associated data. This includes damage values and stamina drain for each style.

**Code Snippet:**

**CombatCharacter.h**
```cpp
#include "AttackStyles.h"

UCLASS()
class YOURPROJECT_API ACombatCharacter : public ACharacter
{
    GENERATED_BODY()

public:
    ACombatCharacter();

    // Properties for Attack Styles
    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Combat")
    EAttackStyle CurrentAttackStyle;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Combat")
    float ThrustDamage;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Combat")
    float SlashDamage;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Combat")
    float OverheadDamage;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Combat")
    float UnderhandedDamage;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Combat")
    float ThrustStaminaDrain;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Combat")
    float SlashStaminaDrain;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Combat")
    float OverheadStaminaDrain;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Combat")
    float UnderhandedStaminaDrain;
};
```

**Explanation:**
- `EAttackStyle CurrentAttackStyle;`: Stores the current attack style in use. This determines which attack style's properties should be applied.
- `ThrustDamage`, `SlashDamage`, `OverheadDamage`, `UnderhandedDamage`: Floating-point values representing the damage dealt by each attack style.
- `ThrustStaminaDrain`, `SlashStaminaDrain`, `OverheadStaminaDrain`, `UnderhandedStaminaDrain`: Floating-point values representing the stamina cost for each attack style.

#### **3. Initialize Attack Style Properties**

**Question:**
Next, we need to initialize these properties with default values. This setup ensures that when we create a new `CombatCharacter`, these properties have sensible initial values.

**Code Snippet:**

**CombatCharacter.cpp**
```cpp
ACombatCharacter::ACombatCharacter()
{
    PrimaryActorTick.bCanEverTick = true;

    // Default values for attack styles
    ThrustDamage = 10.0f;
    SlashDamage = 12.0f;
    OverheadDamage = 15.0f;
    UnderhandedDamage = 8.0f;

    ThrustStaminaDrain = 5.0f;
    SlashStaminaDrain = 6.0f;
    OverheadStaminaDrain = 8.0f;
    UnderhandedStaminaDrain = 4.0f;

    CurrentAttackStyle = EAttackStyle::Thrust; // Default attack style
}
```

**Explanation:**
- `ThrustDamage = 10.0f;`, `SlashDamage = 12.0f;`, `OverheadDamage = 15.0f;`, `UnderhandedDamage = 8.0f;`: Sets the default damage values for each attack style. These can be adjusted in the editor as needed.
- `ThrustStaminaDrain = 5.0f;`, `SlashStaminaDrain = 6.0f;`, `OverheadStaminaDrain = 8.0f;`, `UnderhandedStaminaDrain = 4.0f;`: Sets default stamina costs for each attack style.
- `CurrentAttackStyle = EAttackStyle::Thrust;`: Sets the default attack style to Thrust. This can be changed during gameplay.

#### **4. Implement Attack Logic Based on Style**

**Question:**
We need to implement the logic for performing attacks based on the current attack style. This logic should account for the damage and stamina drain specific to each style.

**Code Snippet:**

**CombatCharacter.cpp**
```cpp
void ACombatCharacter::PerformAttack()
{
    float Damage;
    float StaminaDrain;

    switch (CurrentAttackStyle)
    {
    case EAttackStyle::Thrust:
        Damage = ThrustDamage;
        StaminaDrain = ThrustStaminaDrain;
        break;
    case EAttackStyle::Slash:
        Damage = SlashDamage;
        StaminaDrain = SlashStaminaDrain;
        break;
    case EAttackStyle::Overhead:
        Damage = OverheadDamage;
        StaminaDrain = OverheadStaminaDrain;
        break;
    case EAttackStyle::Underhanded:
        Damage = UnderhandedDamage;
        StaminaDrain = UnderhandedStaminaDrain;
        break;
    default:
        Damage = 0.0f;
        StaminaDrain = 0.0f;
        break;
    }

    // Apply damage and stamina drain logic here
    // ...
}
```

**Explanation:**
- `switch (CurrentAttackStyle)`: Checks the current attack style to determine which damage and stamina drain values to use.
- `Damage` and `StaminaDrain` are set based on the attack style.
- The `PerformAttack` method should include additional logic to apply damage to enemies and handle stamina drain, which would be added in the actual implementation.

### **Summary**

This guide details how to set up attack styles in Unreal Engine 5. We start by defining an enumeration for the attack styles, declaring and initializing properties in the character class, and finally implementing the logic to perform attacks based on the selected style. Each step includes a focused question, a code snippet, and a detailed explanation of how the code contributes to the melee combat system.

Would you like to proceed to the next system or make any adjustments to this one?

Let's dive into implementing the **Combos** system for the melee combat system. This will involve setting up logic to handle successive attacks, including increasing attack speed and stamina cost with each subsequent hit.

### **Step-by-Step Guide to Implementing Combos**

#### **1. Define Combo Properties**

**Question:**
To manage the combo system, we need properties to track the current combo count, the speed increase per combo, and the stamina cost increase. These will help us control how the combo affects attack speed and stamina consumption.

**Code Snippet:**

**CombatCharacter.h**
```cpp
UCLASS()
class YOURPROJECT_API ACombatCharacter : public ACharacter
{
    GENERATED_BODY()

public:
    ACombatCharacter();

    // Combo System Properties
    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Combat")
    int32 ComboCount;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Combat")
    float ComboSpeedIncrease;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Combat")
    float ComboStaminaCostIncrease;

    // Function to handle attacks
    void PerformAttack();
};
```

**Explanation:**
- `ComboCount`: Tracks the number of successful combos executed. This is used to determine how the attack speed and stamina cost are adjusted.
- `ComboSpeedIncrease`: Represents the amount by which the attack speed increases with each combo.
- `ComboStaminaCostIncrease`: Represents the amount by which the stamina cost increases with each combo.

#### **2. Initialize Combo Properties**

**Question:**
We need to set default values for our combo properties. These values will define the initial behavior of the combo system, which can be adjusted as needed during gameplay or in the editor.

**Code Snippet:**

**CombatCharacter.cpp**
```cpp
ACombatCharacter::ACombatCharacter()
{
    PrimaryActorTick.bCanEverTick = true;

    // Default values for combo system
    ComboCount = 0;
    ComboSpeedIncrease = 0.1f; // 10% increase in speed per combo
    ComboStaminaCostIncrease = 1.0f; // 1 unit increase in stamina cost per combo
}
```

**Explanation:**
- `ComboCount = 0;`: Initializes the combo count to zero at the start.
- `ComboSpeedIncrease = 0.1f;`: Sets the default speed increase to 10% per additional combo hit.
- `ComboStaminaCostIncrease = 1.0f;`: Sets the default increase in stamina cost to 1 unit per additional combo hit.

#### **3. Adjust Attack Speed and Stamina Cost in PerformAttack**

**Question:**
We need to update the `PerformAttack` method to adjust the attack speed and stamina cost based on the current combo count. This ensures that each subsequent attack in a combo has the correct speed and cost values.

**Code Snippet:**

**CombatCharacter.cpp**
```cpp
void ACombatCharacter::PerformAttack()
{
    float Damage;
    float StaminaDrain;
    float AttackSpeedMultiplier = 1.0f;
    float StaminaCostMultiplier = 1.0f;

    switch (CurrentAttackStyle)
    {
    case EAttackStyle::Thrust:
        Damage = ThrustDamage;
        StaminaDrain = ThrustStaminaDrain;
        break;
    case EAttackStyle::Slash:
        Damage = SlashDamage;
        StaminaDrain = SlashStaminaDrain;
        break;
    case EAttackStyle::Overhead:
        Damage = OverheadDamage;
        StaminaDrain = OverheadStaminaDrain;
        break;
    case EAttackStyle::Underhanded:
        Damage = UnderhandedDamage;
        StaminaDrain = UnderhandedStaminaDrain;
        break;
    default:
        Damage = 0.0f;
        StaminaDrain = 0.0f;
        break;
    }

    // Apply combo effects
    AttackSpeedMultiplier += ComboCount * ComboSpeedIncrease;
    StaminaCostMultiplier += ComboCount * ComboStaminaCostIncrease;

    // Calculate final attack speed and stamina drain
    float FinalAttackSpeed = AttackSpeedMultiplier;
    float FinalStaminaDrain = StaminaDrain * StaminaCostMultiplier;

    // Apply damage and stamina drain logic here
    // ...

    // Update combo count for next attack
    ComboCount++;
}
```

**Explanation:**
- `AttackSpeedMultiplier` and `StaminaCostMultiplier`: Variables to adjust attack speed and stamina cost based on the current combo count.
- `AttackSpeedMultiplier += ComboCount * ComboSpeedIncrease;`: Increases the attack speed multiplier based on the number of combos.
- `StaminaCostMultiplier += ComboCount * ComboStaminaCostIncrease;`: Increases the stamina cost multiplier based on the number of combos.
- `FinalAttackSpeed` and `FinalStaminaDrain`: Apply the calculated multipliers to determine the final attack speed and stamina drain.
- `ComboCount++`: Increments the combo count after performing the attack.

#### **4. Reset Combo Count After Miss or Successful Attack**

**Question:**
After each attack, we need to determine whether to reset the combo count or keep it. The combo count should be reset if the attack misses or after a short cooldown period if the attack is successful.

**Code Snippet:**

**CombatCharacter.cpp**
```cpp
void ACombatCharacter::ResetCombo()
{
    ComboCount = 0;
}

void ACombatCharacter::PerformAttack()
{
    // Existing attack logic here...

    // After attack logic
    if (/* Check if attack was successful or missed */)
    {
        // Reset combo count if needed
        ResetCombo();
    }
}
```

**Explanation:**
- `ResetCombo()`: Resets the combo count to zero, which is called when an attack misses or after a cooldown period.
- The call to `ResetCombo()` ensures that the combo count is properly managed between attacks.

### **Summary**

In this guide, we have set up the combo system for the melee combat system in Unreal Engine 5. We defined properties to track and adjust the combo count, attack speed, and stamina cost. We then updated the `PerformAttack` method to apply these properties and handle combo logic. Finally, we added functionality to reset the combo count as needed.

Would you like to move on to the next system, Parrying/Riposte, or make any changes to this one?

Let's proceed with the **Parrying/Riposte** system for the melee combat system. This system involves handling the outcome of parries, including successful and failed parries, as well as scenarios where the player lacks stamina.

### **Step-by-Step Guide to Implementing Parrying/Riposte**

#### **1. Define Parrying Properties**

**Question:**
We need properties to manage the parrying mechanics, including the stamina cost of a parry and the conditions for successful or failed parries. These properties will help us handle the different outcomes of a parry.

**Code Snippet:**

**CombatCharacter.h**
```cpp
UCLASS()
class YOURPROJECT_API ACombatCharacter : public ACharacter
{
    GENERATED_BODY()

public:
    ACombatCharacter();

    // Parrying Properties
    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Combat")
    float ParryStaminaCost;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Combat")
    float MinStaminaRequiredForParry;

    // Function to handle parrying
    void ParryAttack();
};
```

**Explanation:**
- `ParryStaminaCost`: The amount of stamina required to perform a parry.
- `MinStaminaRequiredForParry`: The minimum amount of stamina needed to successfully execute a parry.

#### **2. Implement Parry Logic**

**Question:**
We need to implement the `ParryAttack` method to handle the different outcomes of a parry: successful parry, failed parry, and parrying with insufficient stamina.

**Code Snippet:**

**CombatCharacter.cpp**
```cpp
void ACombatCharacter::ParryAttack()
{
    // Check if the player has enough stamina to parry
    if (CurrentStamina >= ParryStaminaCost)
    {
        if (/* Check if parry is successful */)
        {
            // Handle successful parry
            CurrentStamina -= ParryStaminaCost;
            PerformParryAnimation(); // Trigger parry animation
            OpenRiposteWindow(); // Open riposte window for a follow-up attack
        }
        else
        {
            // Handle failed parry
            PlayHitAnimation(); // Trigger hit animation
        }
    }
    else
    {
        // Handle insufficient stamina scenario
        DisarmWeapon(); // Disarm the weapon if stamina is insufficient
        PlayDisarmAnimation(); // Trigger disarm animation
    }
}
```

**Explanation:**
- `if (CurrentStamina >= ParryStaminaCost)`: Checks if the player has enough stamina to perform a parry.
- `if (/* Check if parry is successful */)`: Determines if the parry attempt was successful. The condition should be based on game-specific criteria (e.g., timing, direction).
- `CurrentStamina -= ParryStaminaCost;`: Deducts the stamina cost for the parry.
- `PerformParryAnimation()`: Triggers the animation for a successful parry.
- `OpenRiposteWindow()`: Opens a window for a riposte, allowing the player to follow up with a powerful attack.
- `PlayHitAnimation()`: Plays an animation for a failed parry.
- `DisarmWeapon()`: Disarms the weapon if there is not enough stamina for a parry.
- `PlayDisarmAnimation()`: Plays an animation for weapon disarmament.

#### **3. Handle Riposte Mechanic**

**Question:**
We need to implement the riposte mechanic to allow the player to quickly counterattack after a successful parry. This includes reducing the attack speed and stamina cost of the riposte.

**Code Snippet:**

**CombatCharacter.h**
```cpp
UCLASS()
class YOURPROJECT_API ACombatCharacter : public ACharacter
{
    GENERATED_BODY()

public:
    ACombatCharacter();

    // Riposte Properties
    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Combat")
    float RiposteSpeedMultiplier;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Combat")
    float RiposteStaminaCost;

    void RiposteAttack();
};
```

**Explanation:**
- `RiposteSpeedMultiplier`: The multiplier that increases the speed of the riposte attack.
- `RiposteStaminaCost`: The reduced stamina cost for performing a riposte.

#### **4. Implement Riposte Attack**

**Question:**
We need to implement the `RiposteAttack` method to handle the riposte logic, including applying the speed and stamina multipliers.

**Code Snippet:**

**CombatCharacter.cpp**
```cpp
void ACombatCharacter::RiposteAttack()
{
    if (CurrentStamina >= RiposteStaminaCost)
    {
        float RiposteDamage = BaseDamage * RiposteSpeedMultiplier;
        CurrentStamina -= RiposteStaminaCost;

        // Perform the riposte attack with adjusted speed and damage
        PerformAttack(RiposteDamage);

        // Reset combo count after riposte
        ResetCombo();
    }
    else
    {
        // Handle case where there is not enough stamina for riposte
        PlayOutOfStaminaAnimation(); // Trigger animation for lack of stamina
    }
}
```

**Explanation:**
- `if (CurrentStamina >= RiposteStaminaCost)`: Checks if the player has enough stamina for the riposte.
- `float RiposteDamage = BaseDamage * RiposteSpeedMultiplier;`: Calculates the damage of the riposte attack, taking into account the speed multiplier.
- `CurrentStamina -= RiposteStaminaCost;`: Deducts the stamina cost for the riposte.
- `PerformAttack(RiposteDamage);`: Executes the riposte attack with the calculated damage.
- `ResetCombo();`: Resets the combo count after performing the riposte.
- `PlayOutOfStaminaAnimation();`: Plays an animation if there is insufficient stamina for the riposte.

### **Summary**

In this guide, we have implemented the parrying and riposte mechanics for the melee combat system. We defined properties for managing the stamina cost of parries and ripostes, and implemented logic to handle successful and failed parries, as well as scenarios where stamina is insufficient. We also added functionality for the riposte mechanic, including speed and stamina adjustments.

Would you like to continue with the next system, Attack Manipulation, or make any changes to the current implementation?

Great! Now, let’s dive into the **Attack Manipulation** system, which includes feinting and morphing attacks. We’ll break it down step-by-step, starting from defining properties and methods, to implementing the actual functionality.

### **Step-by-Step Guide to Implementing Attack Manipulation**

#### **1. Define Feinting and Morphing Properties**

**Question:**
We need properties to manage feinting and morphing attacks. This includes stamina costs and timings for the feint/morph window.

**Code Snippet:**

**CombatCharacter.h**
```cpp
UCLASS()
class YOURPROJECT_API ACombatCharacter : public ACharacter
{
    GENERATED_BODY()

public:
    ACombatCharacter();

    // Feinting and Morphing Properties
    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Combat")
    float FeintStaminaCost;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Combat")
    float MorphStaminaCost;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Combat")
    float FeintWindowDuration;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Combat")
    float MorphWindowDuration;

    // Functions to handle feinting and morphing
    void FeintAttack();
    void MorphAttack(EAttackStyle NewStyle);
};
```

**Explanation:**
- `FeintStaminaCost`: The amount of stamina required to perform a feint.
- `MorphStaminaCost`: The amount of stamina required to morph into a different attack style.
- `FeintWindowDuration`: The duration during which a feint can be executed.
- `MorphWindowDuration`: The duration during which a morph can be executed.
- `FeintAttack()`: Method to handle the feinting logic.
- `MorphAttack(EAttackStyle NewStyle)`: Method to handle morphing into a new attack style.

#### **2. Implement Feinting Mechanic**

**Question:**
We need to implement the `FeintAttack` method to allow the player to cancel their current attack and rewind the animation. This method should handle the stamina deduction and animation rewind.

**Code Snippet:**

**CombatCharacter.cpp**
```cpp
void ACombatCharacter::FeintAttack()
{
    if (CurrentStamina >= FeintStaminaCost)
    {
        // Deduct stamina for feinting
        CurrentStamina -= FeintStaminaCost;

        // Trigger feint animation and rewind current attack animation
        PlayFeintAnimation(); // Trigger feint animation
        RewindAttackAnimation(); // Rewind attack animation

        // Allow player to input new attack or action
        EnableInput(); // Enable player input
    }
    else
    {
        // Handle insufficient stamina
        PlayOutOfStaminaAnimation(); // Trigger animation for lack of stamina
    }
}
```

**Explanation:**
- `if (CurrentStamina >= FeintStaminaCost)`: Checks if there is enough stamina to perform a feint.
- `CurrentStamina -= FeintStaminaCost;`: Deducts the stamina required for feinting.
- `PlayFeintAnimation();`: Triggers the animation for feinting.
- `RewindAttackAnimation();`: Rewinds the current attack animation to its start.
- `EnableInput();`: Allows the player to input a new action after feinting.
- `PlayOutOfStaminaAnimation();`: Plays an animation if the player has insufficient stamina.

#### **3. Implement Morphing Mechanic**

**Question:**
We need to implement the `MorphAttack` method to allow the player to change their attack style during the feint/morph window. This includes handling the stamina cost and animation transition.

**Code Snippet:**

**CombatCharacter.cpp**
```cpp
void ACombatCharacter::MorphAttack(EAttackStyle NewStyle)
{
    if (CurrentStamina >= MorphStaminaCost)
    {
        if (IsWithinMorphWindow()) // Check if within morph window duration
        {
            // Deduct stamina for morphing
            CurrentStamina -= MorphStaminaCost;

            // Morph the attack animation to the new style
            MorphToNewStyle(NewStyle); // Morph to new attack style

            // Update the attack style to the new style
            CurrentAttackStyle = NewStyle;

            // Continue the attack with new style
            ContinueAttack(); // Continue attack with new style
        }
        else
        {
            // Handle case where morph window has expired
            PlayMorphWindowExpiredAnimation(); // Trigger animation for expired morph window
        }
    }
    else
    {
        // Handle insufficient stamina
        PlayOutOfStaminaAnimation(); // Trigger animation for lack of stamina
    }
}
```

**Explanation:**
- `if (CurrentStamina >= MorphStaminaCost)`: Checks if there is enough stamina to perform morphing.
- `if (IsWithinMorphWindow())`: Verifies if the player is within the allowed morph window duration.
- `CurrentStamina -= MorphStaminaCost;`: Deducts the stamina required for morphing.
- `MorphToNewStyle(NewStyle);`: Transitions the animation to the new attack style.
- `CurrentAttackStyle = NewStyle;`: Updates the current attack style.
- `ContinueAttack();`: Continues the attack with the new style.
- `PlayMorphWindowExpiredAnimation();`: Plays an animation if the morph window has expired.
- `PlayOutOfStaminaAnimation();`: Plays an animation if the player has insufficient stamina.

#### **4. Handle Feinting and Morphing Window Management**

**Question:**
We need to manage the duration of the feint and morph windows to ensure that the player can only execute these actions within a specific timeframe.

**Code Snippet:**

**CombatCharacter.h**
```cpp
UCLASS()
class YOURPROJECT_API ACombatCharacter : public ACharacter
{
    GENERATED_BODY()

protected:
    virtual void BeginPlay() override;

private:
    bool IsWithinFeintWindow() const;
    bool IsWithinMorphWindow() const;
};
```

**CombatCharacter.cpp**
```cpp
void ACombatCharacter::BeginPlay()
{
    Super::BeginPlay();
    
    // Initialize other components if necessary
}

bool ACombatCharacter::IsWithinFeintWindow() const
{
    // Return true if current time is within the feint window duration
    return (GetWorld()->GetTimeSeconds() - LastAttackTime) <= FeintWindowDuration;
}

bool ACombatCharacter::IsWithinMorphWindow() const
{
    // Return true if current time is within the morph window duration
    return (GetWorld()->GetTimeSeconds() - LastAttackTime) <= MorphWindowDuration;
}
```

**Explanation:**
- `IsWithinFeintWindow()`: Checks if the current time is within the allowed feint window duration based on `LastAttackTime`.
- `IsWithinMorphWindow()`: Checks if the current time is within the allowed morph window duration based on `LastAttackTime`.
- `LastAttackTime` should be updated every time an attack is initiated to keep track of the time window for feints and morphs.

### **Summary**

In this guide, we have implemented the attack manipulation system, including feinting and morphing mechanics. We defined properties for stamina costs and timing windows, and implemented methods to handle feinting and morphing attacks. We also added logic to manage the timing windows for these actions.

Would you like to proceed with additional features or adjustments to the current system?
