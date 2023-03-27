public static class DatingProgress {
    private const int NUM_OWNERS = 3;
    private const int NUM_STAGES = 3;

    // Save the dating progress for the specified owner and stage.
    public static void SaveProgress(int ownerIndex, int stageIndex) {
        PlayerPrefs.SetInt("OwnerIndex", ownerIndex);
        PlayerPrefs.SetInt("StageIndex", stageIndex);
    }

    // Load the saved dating progress.
    public static bool LoadProgress(out int ownerIndex, out int stageIndex) {
        if (PlayerPrefs.HasKey("OwnerIndex") && PlayerPrefs.HasKey("StageIndex")) {
            ownerIndex = PlayerPrefs.GetInt("OwnerIndex");
            stageIndex = PlayerPrefs.GetInt("StageIndex");
            return true;
        }
        ownerIndex = -1;
        stageIndex = -1;
        return false;
    }

    // Set the availability of the specified owner.
    public static void SetOwnerAvailability(int ownerIndex, bool isAvailable) {
        PlayerPrefs.SetInt("Owner" + ownerIndex + "Availability", isAvailable ? 1 : 0);
    }

    // Check if the specified owner is available.
    public static bool IsOwnerAvailable(int ownerIndex) {
        return PlayerPrefs.GetInt("Owner" + ownerIndex + "Availability", 1) == 1;
    }

    // Mark the specified owner as unavailable.
    public static void MarkOwnerAsUnavailable(int ownerIndex) {
        SetOwnerAvailability(ownerIndex, false);
    }

    // Get the dialogue text for the specified owner and stage.
    public static string GetDialogueText(int ownerIndex, int stageIndex) {
        return Resources.Load<TextAsset>("Dating/Owner" + ownerIndex + "/Stage" + stageIndex).text;
    }
}
