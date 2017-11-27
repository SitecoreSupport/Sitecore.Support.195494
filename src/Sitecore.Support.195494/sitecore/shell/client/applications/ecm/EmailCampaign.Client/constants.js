﻿define([], function () {
  return {
    MessageStates: {
      DRAFT: 0,
      DISPATCHSCHEDULED: 1,
      SENDING: 2,
      SENT: 3,
      INACTIVE: 4,
      ACTIVATIONSCHEDULED: 5,
      ACTIVE: 6,
      QUEUING: 7
    },
    SendingStates: {
      UNDEFINED: 0,
      INITIALIZATION: 1,
      QUEUING: 2,
      SENDING: 3,
      PAUSED: 4,
      FINISHING: 5,
      FINISHED: 6
    },
    JsResourcePrefixes: {
        EXM: "/-/speak/v1/ecm/"
    },
    ServerRequests: {
        ACTIVE_REVIEWS: "EXM/ActiveReviews", 
        ADD_MESSAGE_VARIANT: "EXM/AddMessageVariant",
        ADD_PRE_EXISTING_PAGE: "EXM/AddPreExistingPage",
        ADD_RECIPIENT_LIST: "EXM/AddRecipientList",
        APP_CENTER_URL: "EXM/AppCenterUrl",
        CAN_CREATE_NEW_MESSAGE: "EXM/CanCreateNewMessage",
        CAN_DELETE_FOLDER: "EXM/CanDeleteFolder",
        CAN_DELETE_MESSAGE: "EXM/CanDeleteMessage",
        CAN_IMPORT_HTML: "EXM/CanImportHtml",
        CAN_SAVE_DEFAULT_SETTINGS: "EXM/CanSaveDefaultSettings",
        CAN_SAVE_SUBSCRIPTION_TEMPLATE: "EXM/CanSaveSubscriptionTemplate",
        CHECK_PERMISSIONS: "EXM/CheckPermissions",
        CHECK_RECIPIENT_LISTS: "EXM/CheckRecipientLists",
        COPY_TO_DRAFT: "EXM/CopyToDraft",
        CREATE_NEW_MESSAGE: "EXM/CreateNewMessage",
        CREATE_REPORT_REPEATER_ITEM: "EXM/CreateReportRepeaterItem",
        CURRENT_STATE: "EXM/CurrentState",
        DELETE_FOLDER: "EXM/DeleteFolder",
        DELETE_MESSAGE: "EXM/DeleteMessage",
        DUPLICATE_MESSAGE_VARIANT: "EXM/DuplicateMessageVariant",
        EMAIL_CHANNEL_PERFORMANCE_REPORT_KEY: "EXM/EmailChannelPerformanceReportKey",
        EMAIL_PREVIEW_STATE: "EXM/EmailPreviewState",
        ENGAGEMENT_PLAN_URL: "EXM/EngagementPlanUrl",
        EXPERIENCE_ANALYTICS_KEY: 'EXM/ExperienceAnalyticsKey',
        EXECUTE_EMAIL_PREVIEW: "EXM/ExecuteEmailPreview",
        EXECUTE_SEND_QUICK_TEST: "EXM/ExecuteSendQuickTest",
        EXECUTE_SPAM_CHECK: "EXM/ExecuteSpamCheck",
        FIRST_USAGE: "EXM/FirstUsage",
        IMPORT_HTML: "EXM/ImportHtml",
        INITIAL_ACTIVE_REVIEWS: "EXM/InitialActiveReviews",
        IS_PREVIEW_SERVICE_PURCHASED: "EXM/IsPreviewServicePurchased",
        IS_SPAM_CHECK_SERVICE_PURCHASED: "EXM/IsSpamCheckServicePurchased",
        LOAD_DEFAULT_SETTINGS: "EXM/LoadDefaultSettingsEx/1/LoadDefaultSettingsLang",//support fix for 195494
        LIST_MANAGEMENT_CONTACT_LIST: "ListManagement/ContactList",
        MESSAGE_INFO: "EXM/MessageInfo",
        MESSAGE_PREVIEW_URL: "EXM/MessagePreviewUrl",
        MESSAGE_URL: "EXM/MessageUrl",
        PUBLISH_STATISTICS: 'EXM/PublishStatistics',
        RECIPIENT_LISTS: "EXM/RecipientLists",
        REMOVE_ATTACHMENT: "EXM/RemoveAttachment",
        REMOVE_BOUNCED_CONTACTS: "EXM/RemoveBouncedContacts",
        REMOVE_COMPLAINED_CONTACTS: "EXM/RemoveComplainedContacts",
        REMOVE_MESSAGE_VARIANT: "EXM/RemoveMessageVariant",
        REMOVE_REPORT_REPEATER_ITEM: "EXM/RemoveReportRepeaterItem",
        REMOVE_UNSUBSCRIBED_CONTACTS: "EXM/RemoveUnsubscribedContacts",
        REPORT_KEY: "EXM/ReportKey",
        REVOME_RECIPIENT_LIST: "EXM/RemoveRecipientList",
        SAVE_DEFAULT_SETTINGS: "EXM/SaveDefaultSettingsEx/1/SaveDefaultSettingsLang",//support fix for 195494
        SAVE_MESSAGE: "EXM/SaveMessage",
        SPAM_CHECK_STATE: "EXM/SpamCheckState",
        SWITCH_LANGUAGE: "EXM/SwitchLanguage",
        VALIDATE_DEFAULT_SETTINGS: "EXM/ValidateDefaultSettings",
        VALIDATE_PAGE_PATH: "EXM/ValidatePagePath",
        VALIDATE_SELECTED_CLIENTS: "EXM/ValidateSelectedClients",
        VALIDATE_SENDER: "EXM/ValidateSender"
    },
    Reporting: {
        Events: {
            OPEN: 1,
            CLICK: 4,
            FIRST_CLICK: 8,
            UNSUBSCRIBE: 16,
            BOUNCE: 32,
            SENT: 64,
            SPAM: 128
        }
    },
    URLs: {
        MessagesOneTime: "/sitecore/client/Applications/ECM/Pages/Messages/OneTime",
        MessagesTriggered: "/sitecore/client/Applications/ECM/Pages/Messages/Triggered",
        MessagesSubscription: "/sitecore/client/Applications/ECM/Pages/Messages/Subscription",
        MessageReport: '/sitecore/client/Applications/ECM/Pages/CampaignReport',
        Dashboard: "/sitecore/client/Applications/ECM/Pages/Dashboard",
        EdsDomains: '/sitecore/client/Applications/EDS/Pages/Domains'
    }
  }
});